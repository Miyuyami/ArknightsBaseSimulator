using System;
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

        private Slot GetSlot(SlotData slotData) => this.BaseLayout.Slots[slotData.Id];
        private Slot GetSlot(string id) => this.BaseLayout.Slots[id];
        public bool TryGetSlot(SlotData slotData, out Slot slot) => this.BaseLayout.Slots.TryGetValue(slotData.Id, out slot);

        public IEnumerable<RoomSlotData> GetRoomSlots() => this.SaveData.Slots.OfType<RoomSlotData>();
        public IEnumerable<RoomSlotData> GetRoomSlots(RoomType roomType) => this.GetRoomSlots().Where(r => r.RoomType == roomType);

        private Storey GetStorey(Slot slot) => this.BaseLayout.Storeys[slot.StoreyId];
        private bool TryGetSlotData(string key, out SlotData slotData) => this.SaveData.Slots.TryGetValue(key, out slotData);
        private bool TryGetSlotData(Slot slot, out SlotData slotData) => this.SaveData.Slots.TryGetValue(slot.Id, out slotData);
        private void SetSlotData(Slot slot, SlotData slotData) => this.SaveData.Slots[slot.Id] = slotData;

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

        public IEnumerable<Cost> GetCleanCosts(Slot slot)
        {
            var room = this.GetPossibleBuildRooms(slot)
                           .First();

            return this.BaseLayout.CleanCostTypes[slot.CleanCostId]
                                  .Number[this.GetRoomCount(room.Id)]
                                  .Items;
        }

        public BuildCost GetRoomUpgradeCosts(Room room) =>
            this.GetRoomPhaseCost(room, 1 + this.GetRoomCount(room.Id));

        public IEnumerable<Cost> GetRoomDowngradeRefund(Room room) =>
            this.GetRoomPhaseCost(room, this.GetRoomCount(room.Id)).Items;

        private BuildCost GetRoomPhaseCost(Room room, int phase)
        {
            if (room.Phases.Count < phase)
            {
                throw new ArgumentException("Given phase doesn't exist.", nameof(phase));
            }

            return room.Phases[phase].BuildCost;
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

        public IEnumerable<Room> GetPossibleBuildRooms(Slot slot) => this.BaseData.Rooms.Values.Where(r =>
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

            this.SaveData.Slots[slot.Id] = new EmptySlotData(slot.Id);
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

        public bool CanBuild(Slot slot, Room room) => this.SlotHelper<EmptySlotData>(this.CanBuild, slot, room);
        public bool CanBuild(EmptySlotData slotData, Room room) => this.SlotHelper(this.CanBuild, slotData, room);
        private bool CanBuild(Slot slot, Room room, EmptySlotData slotData)
        {
            if (this.GetRoomSlots(room.Id).Count() >= room.MaxCount)
            {
                return false;
            }

            return this.DoesMeetBuildRequirements(room);
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

        private bool IsRequirementMet(BuildRequirement br) =>
            br.RoomType switch
            {
                RoomTypeCondition.None => true,
                RoomTypeCondition.Functional => this.GetRoomSlots().Where(r => r.Level >= br.Level).Count() >= br.Count,
                _ => this.GetRoomSlots(br.RoomType.ToRoomType()).Where(r => r.Level >= br.Level).Count() >= br.Count,
            };

        public bool DoesMeetBuildRequirements(Room room) =>
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
            var roomPhase = room.Phases[level - 1];
            if (this.BaseData.RoomUnlockConds.TryGetValue(roomPhase.UnlockCondId, out RoomConditions roomConditions))
            {
                var roomCond = roomConditions.Number[roomCount];

                yield return new BuildRequirement(roomCond.Type, roomCond.Level, roomCond.Count);
            }
        }

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
