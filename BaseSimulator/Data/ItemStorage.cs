using System;
using System.Linq;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class ItemStorage
    {
        private ItemTable ItemTable { get; }
        private SaveData SaveData { get; }

        public Item BaseApItem { get; }
        public ItemData BaseApItemData => this.SaveData.Items[this.BaseApItem.ItemId];

        public ItemStorage(SaveData saveData, ItemTable itemTable)
        {
            this.SaveData = saveData;
            this.ItemTable = itemTable;

            this.BaseApItem = this.ItemTable.Items.Values.Single(i => i.ItemType == ItemType.BaseAp);

            this.AddItem(this.BaseApItem.ItemId, 0); // ensure we have base ap in save data
        }

        public bool TryGetItem(string itemId, out Item item) =>
            this.ItemTable.Items.TryGetValue(itemId, out item);

        public bool TryGetItemData(string itemId, out ItemData itemData) =>
            this.SaveData.Items.TryGetValue(itemId, out itemData);

        public void AddItem(string itemId, long count)
        {
            if (this.TryGetItemData(itemId, out ItemData itemData))
            {
                itemData.Count = this.Bound(itemData.Count + count);
            }
            else
            {
                this.InternalAddItem(itemId, count);
            }
        }

        public void RemoveItem(string itemId, long count) =>
            this.AddItem(itemId, -count);

        private long Bound(long count) => Math.Max(count, 0);

        private void InternalAddItem(string itemId, long count) =>
            this.SaveData.Items[itemId] = new ItemData(itemId, this.Bound(count));
    }
}
