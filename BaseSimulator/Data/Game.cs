﻿using System;
using System.Collections.Generic;
using System.Linq;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class Game
    {
        public const double OneSlotUnitSize = 50;

        public SaveData SaveData { get; }
        public BaseData BaseData { get; }

        public long MaxLayoutHeight { get; }
        public Layout BaseLayout => this.BaseData.Layouts[LayoutVersion.V0];

        private Slot ControlSlot => this.BaseLayout.Slots[this.BaseData.ControlSlotId];
        private SlotData ControlSlotData => this.SaveData.Slots[this.BaseData.ControlSlotId];
        private Slot MeetingSlot => this.BaseLayout.Slots[this.BaseData.MeetingSlotId];
        private SlotData MeetingSlotData => this.SaveData.Slots[this.BaseData.MeetingSlotId];

        public Game(SaveData saveData, BaseData baseData)
        {
            this.SaveData = saveData;
            this.BaseData = baseData;

            var slotsNotPresent = this.BaseLayout.Slots.Keys.Where(x => !this.SaveData.Slots.ContainsKey(x));
            foreach (var s in slotsNotPresent)
            {
                this.SaveData.Slots.Add(s, new LockedSlotData(s));
            }

            this.MaxLayoutHeight = this.BaseLayout.Slots.Values.Max(s => s.Offset.Row + s.Size.Row);
        }

        public int LevelToPhase(int level) => level - 1;
        public string ManpowerToString(int manpower) => ((double)manpower / 100).ToString("n2");
        public string ManpowerCharacterToString(int manpower) => ((double)manpower / this.BaseData.ManpowerDisplayFactor).ToString("n0");

        private Slot GetSlot(SlotData slotData) => this.BaseLayout.Slots[slotData.Id];
        private Slot GetSlot(string id) => this.BaseLayout.Slots[id];
        public bool TryGetSlot(SlotData slotData, out Slot slot) => this.BaseLayout.Slots.TryGetValue(slotData.Id, out slot);

        private Room GetRoom(RoomType roomType) => this.BaseData.Rooms[roomType];
        public bool TryGetRoom(RoomType roomType, out Room room) => this.BaseData.Rooms.TryGetValue(roomType, out room);

        public IEnumerable<RoomSlotData> GetRoomSlots() => this.SaveData.Slots.OfType<RoomSlotData>();
        public IEnumerable<RoomSlotData> GetRoomSlots(RoomType roomType) => this.GetRoomSlots().Where(r => r.RoomType == roomType);

        private Storey GetStorey(Slot slot) => this.BaseLayout.Storeys[slot.StoreyId];
        private bool TryGetSlotData(string key, out SlotData slotData) => this.SaveData.Slots.TryGetValue(key, out slotData);
        private bool TryGetSlotData(Slot slot, out SlotData slotData) => this.SaveData.Slots.TryGetValue(slot.Id, out slotData);
        private void SetSlotData(Slot slot, SlotData slotData) => this.SaveData.Slots[slot.Id] = slotData;

        public bool TryGetRoomData(Slot slot, out RoomSlotData roomSlotData)
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                roomSlotData = null;
                return false;
            }

            if (!(slotData is RoomSlotData roomSlotDataValue))
            {
                roomSlotData = null;
                return false;
            }

            roomSlotData = roomSlotDataValue;
            return true;
        }

        public int GetRoomCount(RoomType roomType) =>
            this.SaveData.Slots.OfType<RoomSlotData>()
                               .Where(r => r.RoomType == roomType)
                               .Count();

        public int GetItemCount(string itemId)
        {
            if (this.SaveData.Items.TryGetValue(itemId, out ItemData itemData))
            {
                return itemData.Count;
            }

            return 0;
        }

        public string GetItemName(string id) =>
            id switch
            {
                "3105" => "Mat S",
                "3131" => "Mat 1",
                "3132" => "Mat 2",
                "3133" => "Mat 3",
                "base_ap" => "Drone",
                _ => throw new KeyNotFoundException(),
            };

        // TODO: return BuildCost
        public IEnumerable<Cost> GetCleanCosts(Slot slot)
        {
            var room = this.GetPossibleBuildRooms(slot)
                           .First();

            return this.BaseLayout.CleanCostTypes[slot.CleanCostId]
                                  .Number[this.GetRoomCount(room.Id)]
                                  .Items;
        }

        public BuildCost GetNewRoomBuildCost(Room room) => this.GetRoomBuildCost(room, 1);

        public BuildCost GetRoomUpgradeCosts(Slot slot)
        {
            if (!this.TryGetRoomData(slot, out RoomSlotData roomSlotData))
            {
                throw new Exception("slot not found");
            }

            var room = this.GetRoom(roomSlotData.RoomType);

            return this.GetRoomBuildCost(room, roomSlotData.Level + 1);
        }

        public BuildCost GetRoomDowngradeRefundCost(Slot slot)
        {
            if (!this.TryGetRoomData(slot, out RoomSlotData roomSlotData))
            {
                throw new Exception("slot not found");
            }

            var room = this.GetRoom(roomSlotData.RoomType);

            return this.GetRoomBuildCost(room, roomSlotData.Level);
        }

        private BuildCost GetRoomBuildCost(Room room, int level)
        {
            var phaseIdx = this.LevelToPhase(level);
            if (phaseIdx >= room.Phases.Count)
            {
                return null;
                throw new ArgumentException("Given level doesn't exist.", nameof(level));
            }

            return room.Phases[phaseIdx].BuildCost;
        }

        public string GetLaborName() =>
            this.GetItemName("base_ap");
        public int GetLaborCount() =>
            this.GetItemCount("base_ap");
        public int GetMaxLabor() =>
            this.SaveData.Slots.Values.Where(sd => this.IsUnlocked(sd))
                                      .Select(sd => this.GetSlot(sd.Id))
                                      .Select(s => s.ProvideLabor)
                                      .Sum();
        public bool IsUnlocked(SlotData slotData) =>
            !(slotData is LockedSlotData);

        public IEnumerable<Room> GetPossibleBuildRooms(Slot slot) => this.SlotHelper(this.GetPossibleBuildRooms, slot);
        public IEnumerable<Room> GetPossibleBuildRooms(SlotData slotData) => this.SlotHelper(this.GetPossibleBuildRooms, slotData);
        public IEnumerable<Room> GetPossibleBuildRooms(Slot slot, SlotData slotData) =>
            this.BaseData.Rooms.Values.Where(r =>
                slot.Category switch
                {
                    RoomCategory.Elevator => r.Id == RoomType.Elevator,
                    RoomCategory.Corridor => r.Id == RoomType.Corridor,
                    RoomCategory.Special => r.Id == RoomType.Control,
                    _ => r.Category == slot.Category,
                });

        public bool TryUnlock(Slot slot) => this.SlotHelper<LockedSlotData>(this.TryUnlock, slot);
        public bool TryUnlock(LockedSlotData slotData) => this.SlotHelper(this.TryUnlock, slotData);
        public bool TryUnlock(Slot slot, LockedSlotData slotData)
        {
            if (!this.CanUnlock(slot, slotData))
            {
                return false;
            }

            var emptySlotData = new EmptySlotData(slot.Id);
            this.SaveData.Slots[slot.Id] = emptySlotData;

            if (this.TryInstantBuild(slot, emptySlotData, out RoomSlotData roomSlotData))
            {
                this.SaveData.Slots[slot.Id] = roomSlotData;
            }

            return true;
        }

        public bool CanUnlock(Slot slot) => this.SlotHelper<LockedSlotData>(this.CanUnlock, slot);
        public bool CanUnlock(LockedSlotData slotData) => this.SlotHelper(this.CanUnlock, slotData);
        private bool CanUnlock(Slot slot, LockedSlotData slotData)
        {
            return slot.StoreyId switch
            {
                StoreyId.None => true,
                _ => this.DoesMeetUnlockRequirements(slot, slotData),
            };
        }

        private bool TryInstantBuild(Slot slot, EmptySlotData emptySlotData, out RoomSlotData roomSlotData)
        {
            switch (slot.Category)
            {
                case RoomCategory.Elevator:
                    if (this.CanBuild(slot, this.GetRoom(RoomType.Elevator), emptySlotData))
                    {
                        roomSlotData = new RoomSlotData(slot.Id, RoomType.Elevator, 1);
                        return true;
                    }
                    break;
                case RoomCategory.Corridor:
                    if (this.CanBuild(slot, this.GetRoom(RoomType.Elevator), emptySlotData))
                    {
                        roomSlotData = new RoomSlotData(slot.Id, RoomType.Corridor, 1);
                        return true;
                    }
                    break;
            }

            roomSlotData = null;
            return false;
        }

        private bool TryBuild(Slot slot, Room room, EmptySlotData slotData)
        {
            if (!this.CanBuild(slot, room, slotData))
            {
                return false;
            }

            // TODO:
            throw new NotImplementedException();
        }

        public bool CanBuildAny(Slot slot) => this.SlotHelper<EmptySlotData>(this.CanBuildAny, slot);
        public bool CanBuildAny(EmptySlotData slotData) => this.SlotHelper(this.CanBuildAny, slotData);
        public bool CanBuildAny(Slot slot, EmptySlotData slotData) =>
            this.GetPossibleBuildRooms(slot)
                .Any(r => this.CanBuild(slot, r, slotData));

        public bool CanBuild(Slot slot, Room room) => this.SlotHelper<EmptySlotData>(this.CanBuild, slot, room);
        public bool CanBuild(EmptySlotData slotData, Room room) => this.SlotHelper(this.CanBuild, slotData, room);
        private bool CanBuild(Slot slot, Room room, EmptySlotData slotData)
        {
            if (room.MaxCount != -1 &&
                this.GetRoomSlots(room.Id).Count() >= room.MaxCount)
            {
                return false;
            }

            return this.DoesMeetBuildNewRequirements(room);
        }

        private bool TryUpgrade(Slot slot, Room room, RoomSlotData slotData)
        {
            if (!this.CanUpgrade(slot, room, slotData))
            {
                return false;
            }

            // TODO:
            throw new NotImplementedException();
        }

        public bool CanUpgrade(Slot slot, Room room) => this.SlotHelper<RoomSlotData>(this.CanUpgrade, slot, room);
        public bool CanUpgrade(RoomSlotData slotData, Room room) => this.SlotHelper(this.CanUpgrade, slotData, room);
        private bool CanUpgrade(Slot slot, Room room, RoomSlotData slotData)
        {
            if (slotData.Level >= room.Phases.Count)
            {
                return false;
            }

            return this.DoesMeetUpgradeRequirements(slot, room, slotData);
        }

        public bool DoesMeetUnlockRequirements(Slot slot) => this.SlotHelper<LockedSlotData>(this.DoesMeetUnlockRequirements, slot);
        public bool DoesMeetUnlockRequirements(LockedSlotData slotData) => this.SlotHelper(this.DoesMeetUnlockRequirements, slotData);
        private bool DoesMeetUnlockRequirements(Slot slot, LockedSlotData slotData) =>
            this.GetUnlockRequirements(slot, slotData)
                .All(this.IsRequirementMet);

        private bool IsRequirementMet(RequireRoom rr) => this.IsRequirementMet(new BuildRequirement(rr.RoomType, rr.RoomLevel, rr.RoomCount));
        private bool IsRequirementMet(BuildRequirement br) =>
            br.RoomType switch
            {
                RoomTypeCondition.None => true,
                RoomTypeCondition.Functional => this.GetRoomSlots().Where(r => r.Level >= br.Level).Count() >= br.Count,
                _ => this.GetRoomSlots(br.RoomType.ToRoomType()).Where(r => r.Level >= br.Level).Count() >= br.Count,
            };

        public bool DoesMeetBuildNewRequirements(Room room) =>
            this.GetBuildNewRequirements(room)
                .All(this.IsRequirementMet);

        public bool DoesMeetUpgradeRequirements(Slot slot, Room room) => this.SlotHelper<RoomSlotData>(this.DoesMeetUpgradeRequirements, slot, room);
        public bool DoesMeetUpgradeRequirements(RoomSlotData slotData, Room room) => this.SlotHelper(this.DoesMeetUpgradeRequirements, slotData, room);
        public bool DoesMeetUpgradeRequirements(Slot slot, Room room, RoomSlotData slotData) =>
            this.GetBuildUpgradeRequirements(slot, room, slotData)
                .All(this.IsRequirementMet);

        public bool IsConnected(Slot slot) => this.SlotHelper<SlotData>(this.IsConnected, slot);
        public bool IsConnected(SlotData slotData) => this.SlotHelper(this.IsConnected, slotData);
        private bool IsConnected(Slot slot, SlotData slotData)
        {
            return true;
        }

        public IEnumerable<BuildRequirement> GetUnlockRequirements(Slot slot) => this.SlotHelper(this.GetUnlockRequirements, slot);
        public IEnumerable<BuildRequirement> GetUnlockRequirements(SlotData slotData) => this.SlotHelper(this.GetUnlockRequirements, slotData);
        public IEnumerable<BuildRequirement> GetUnlockRequirements(Slot slot, SlotData slotData)
        {
            var storey = this.GetStorey(slot);

            yield return new BuildRequirement(RoomTypeCondition.Control, storey.UnlockControlLevel, 1);
        }

        public IEnumerable<BuildRequirement> GetBuildNewRequirements(Room room)
        {
            var roomCount = this.GetRoomCount(room.Id);

            return this.GetBuildRequirements(room, 1, roomCount + 1);
        }

        public IEnumerable<BuildRequirement> GetBuildUpgradeRequirements(Slot slot, Room room) => this.SlotHelper<BuildRequirement, RoomSlotData>(this.GetBuildUpgradeRequirements, slot, room);
        public IEnumerable<BuildRequirement> GetBuildUpgradeRequirements(RoomSlotData slotData, Room room) => this.SlotHelper(this.GetBuildUpgradeRequirements, slotData, room);
        public IEnumerable<BuildRequirement> GetBuildUpgradeRequirements(Slot slot, Room room, RoomSlotData slotData)
        {
            var roomCount = this.GetRoomCount(room.Id);

            return this.GetBuildRequirements(room, slotData.Level + 1, roomCount);
        }

        private IEnumerable<BuildRequirement> GetBuildRequirements(Room room, int level, int roomCount)
        {
            var roomPhase = room.Phases[this.LevelToPhase(level)];
            if (this.BaseData.RoomUnlockConds.TryGetValue(roomPhase.UnlockCondId, out RoomConditions roomConditions))
            {
                var roomCond = roomConditions.Number[roomCount];

                yield return new BuildRequirement(roomCond.Type, roomCond.Level, roomCond.Count);
            }
        }

        public IEnumerable<WorkshopFormula> GetWorkshopFormulas(int level, int roomCount) =>
            this.BaseData.WorkshopFormulas.Values.Where(w =>
                w.RequireRooms.All(r => r.RoomType == RoomTypeCondition.Workshop &&
                                        r.RoomLevel == level &&
                                        r.RoomCount <= roomCount));
        public IEnumerable<WorkshopFormula> GetUnlockedWorkshopFormulas() =>
            this.BaseData.WorkshopFormulas.Values.Where(w => w.RequireRooms.All(this.IsRequirementMet));


        #region Slot helpers
        private bool SlotHelper<SD>(Func<Slot, Room, SD, bool> func, Slot slot, Room room) where SD : SlotData
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                return false;
            }

            if (!(slotData is SD sd))
            {
                return false;
            }

            return func(slot, room, sd);
        }
        private bool SlotHelper<SD>(Func<Slot, Room, SD, bool> func, SD slotData, Room room) where SD : SlotData
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                return false;
            }

            return func(slot, room, slotData);
        }

        private bool SlotHelper<SD>(Func<Slot, SD, bool> func, Slot slot) where SD : SlotData
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                return false;
            }

            if (!(slotData is SD sd))
            {
                return false;
            }

            return func(slot, sd);
        }
        private bool SlotHelper<SD>(Func<Slot, SD, bool> func, SD slotData) where SD : SlotData
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                return false;
            }

            return func(slot, slotData);
        }

        private IEnumerable<T> SlotHelper<T, SD>(Func<Slot, Room, SD, IEnumerable<T>> func, Slot slot, Room room) where SD : SlotData
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                yield break;
            }

            if (!(slotData is SD sd))
            {
                yield break;
            }

            foreach (var t in func(slot, room, sd))
            {
                yield return t;
            }
        }
        private IEnumerable<T> SlotHelper<T, SD>(Func<Slot, Room, SD, IEnumerable<T>> func, SD slotData, Room room) where SD : SlotData
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                yield break;
            }

            foreach (var t in func(slot, room, slotData))
            {
                yield return t;
            }
        }

        private IEnumerable<T> SlotHelper<T>(Func<Slot, SlotData, IEnumerable<T>> func, Slot slot)
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                yield break;
            }

            foreach (var t in func(slot, slotData))
            {
                yield return t;
            }
        }
        private IEnumerable<T> SlotHelper<T>(Func<Slot, SlotData, IEnumerable<T>> func, SlotData slotData)
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                yield break;
            }

            foreach (var t in func(slot, slotData))
            {
                yield return t;
            }
        }
        #endregion
    }

    public class BuildRequirement
    {
        public RoomTypeCondition RoomType { get; }
        public int Level { get; }
        public int Count { get; }

        public BuildRequirement(RoomTypeCondition roomType, int level, int count)
        {
            this.RoomType = roomType;
            this.Level = level;
            this.Count = count;
        }
    }
}
