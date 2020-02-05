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

        private Storey GetStorey(Slot slot) => this.BaseLayout.Storeys[slot.StoreyId];
        private bool TryGetSlotData(string key, out SlotData slotData) => this.SaveData.Slots.TryGetValue(key, out slotData);
        private bool TryGetSlotData(Slot slot, out SlotData slotData) => this.SaveData.Slots.TryGetValue(slot.Id, out slotData);
        private void SetSlotData(Slot slot, SlotData slotData) => this.SaveData.Slots[slot.Id] = slotData;
        //private bool TryGetRoomData(Slot slot, out RoomData roomData) => this.SaveData.Slots.

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
                                  .CleanCostByNumber[this.GetRoomCount(room.Id)]
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

        //public bool TryBuildNew(Slot slot, Room room)
        //{
        //    if (!this.TryGetSlotData(slot, out SlotData slotData))
        //    {
        //        return false;
        //    }

        //    if (slotData is RoomSlotData)
        //    {
        //        return false;
        //    }

        //    if (!this.GetPossibleBuildRooms(slot)
        //             .Select(r => r.Id)
        //             .Contains(room.Id))
        //    {
        //        return false;
        //    }

        //    this.SetSlotData(slot, new RoomSlotData(slot.Id, room.Id, 1));
        //    return true;
        //}

        //public bool TryUpgrade(Slot slot)
        //{
        //    if (!this.TryGetSlotData(slot, out SlotData slotData))
        //    {
        //        return false;
        //    }

        //    return this.TryUpgrade(slot, slotData.Room);
        //}

        ////private bool TryUpgrade(Slot slot, Room room)
        ////{
        ////    if (this.DoesMeetRequirements(slot, room))
        ////    {
        ////        //this.TryUpgradeInternal(slot, slotData);
        ////    }
        ////}

        //private bool TryUpgrade(Slot slot, RoomSlotData roomSlotData)
        //{
        //    if (!this.CanUpgrade(slot, roomData))
        //    {
        //        return false;
        //    }

        //    roomData.Level++;
        //    return true;
        //}

        //public bool TryUnlock(Slot slot)
        //{
        //    if (this.CanUnlock(slot))
        //    {
        //        this.SaveData.Slots[slot.Id] = new SlotData(slot.Id);
        //        return true;
        //    }

        //    return false;
        //}

        public bool CanUnlock(Slot slot) => this.SlotHelper(this.CanUnlock, slot);
        public bool CanUnlock(SlotData slotData) => this.SlotHelper(this.CanUnlock, slotData);
        private bool CanUnlock(Slot slot, SlotData slotData)
        {
            if (!(slotData is LockedSlotData lockedSlotData))
            {
                return false;
            }

            switch (slot.StoreyId)
            {
                case StoreyId.None:
                    return true;
                default:
                    return DoesMeetUnlockRequirements(slot, slotData);
            }
        }

        public bool DoesMeetUnlockRequirements(Slot slot) => this.SlotHelper(this.DoesMeetUnlockRequirements, slot);
        public bool DoesMeetUnlockRequirements(SlotData slotData) => this.SlotHelper(this.DoesMeetUnlockRequirements, slotData);
        private bool DoesMeetUnlockRequirements(Slot slot, SlotData slotData)
        {
            var storey = this.GetStorey(slot);

            if (storey.UnlockControlLevel <= 0)
            {
                return this.IsConnected(slot, slotData);
            }

            if (this.ControlSlotData is RoomSlotData controlSlotData)
            {
                return controlSlotData.Level >= storey.UnlockControlLevel;
            }

            return false;
        }

        public bool IsConnected(Slot slot) => this.SlotHelper(this.IsConnected, slot);
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

            yield return new BuildRequirement(RoomType.Control, storey.UnlockControlLevel, 1);
        }

        //private bool DoesMeetRequirements(Slot slot, Room room)
        //{
        //    this.BaseData.Rooms.Values.Where(r => r.Category)
        //}

        private bool SlotHelper(Func<Slot, SlotData, bool> func, Slot slot)
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                return false;
            }

            return func(slot, slotData);
        }

        private bool SlotHelper(Func<Slot, SlotData, bool> func, SlotData slotData)
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                return false;
            }

            return func(slot, slotData);
        }

        private T SlotHelper<T>(Func<Slot, SlotData, T> func, Slot slot)
        {
            if (!this.TryGetSlotData(slot, out SlotData slotData))
            {
                throw new Exception("Could not find given slot.");
            }

            return func(slot, slotData);
        }

        private T SlotHelper<T>(Func<Slot, SlotData, T> func, SlotData slotData)
        {
            if (!this.TryGetSlot(slotData, out Slot slot))
            {
                throw new Exception("Could not find given slot.");
            }

            return func(slot, slotData);
        }
    }

    public class BuildRequirement
    {
        public RoomType RoomType { get; }
        public int Level { get; }
        public int Count { get; }

        public BuildRequirement(RoomType roomType, int level, int count)
        {
            this.RoomType = roomType;
            this.Level = level;
            this.Count = count;
        }
    }
}
