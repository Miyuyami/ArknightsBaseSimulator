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
        public ItemData BaseApItemData { get; }

        public Item GoldItem { get; }
        public ItemData GoldItemData { get; }

        public ItemStorage(SaveData saveData, ItemTable itemTable)
        {
            this.SaveData = saveData;
            this.ItemTable = itemTable;

            this.BaseApItem = this.ItemTable.Items.Values.Single(i => i.ItemType == ItemType.BaseAp);
            this.GoldItem = this.ItemTable.Items.Values.Single(i => i.ItemType == ItemType.Gold);

            // ensure we have required items in save data
            this.AddItem(this.BaseApItem, 0);
            this.AddItem(this.GoldItem, 0);

            this.BaseApItemData = this.GetItemData(this.BaseApItem);
            this.GoldItemData = this.GetItemData(this.GoldItem);

            this.Debug_SetDefaultItems();
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void Debug_SetDefaultItems()
        {
            void helper(string itemId, long count)
            {
                this.AddItem(itemId, 0);
                this.GetItemData(itemId).Count = count;
            }

            helper("3131", 10);
            helper("3132", 10);
            helper("3133", 10);
            helper("3105", 5);
        }

        private ItemData GetItemData(Item item) => this.GetItemData(item.ItemId);
        private ItemData GetItemData(string itemId) => this.SaveData.Items[itemId];

        public bool TryGetItem(ItemData itemData, out Item item) => this.TryGetItem(itemData.Id, out item);
        public bool TryGetItem(string itemId, out Item item) =>
            this.ItemTable.Items.TryGetValue(itemId, out item);

        public bool TryGetItemData(Item item, out ItemData itemData) => this.TryGetItemData(item.ItemId, out itemData);
        public bool TryGetItemData(string itemId, out ItemData itemData)
        {
            if (this.SaveData.Items.TryGetValue(itemId, out itemData))
            {
                return true;
            }

            if (!this.TryGetItem(itemId, out Item _))
            {
                return false;
            }

            itemData = this.InternalAddItem(itemId, 0);
            return true;
        }

        public ItemData AddItem(Item item, long count) => this.AddItem(item.ItemId, count);
        public ItemData AddItem(string itemId, long count)
        {
            if (this.TryGetItemData(itemId, out ItemData itemData))
            {
                itemData.Count = this.Bound(itemData.Count + count);
                return itemData;
            }
            else
            {
                return this.InternalAddItem(itemId, count);
            }
        }

        private ItemData RemoveItem(Item item, long count) => this.RemoveItem(item.ItemId, count);
        private ItemData RemoveItem(string itemId, long count) =>
            this.AddItem(itemId, -count);
        public bool TryRemoveItem(Item item, long count) => this.TryRemoveItem(item.ItemId, count);
        public bool TryRemoveItem(string itemId, long count)
        {
            if (!this.TryGetItemData(itemId, out ItemData itemData))
            {
                return false;
            }

            if (itemData.Count < count)
            {
                return false;
            }

            this.RemoveItem(itemId, count);
            return true;
        }

        private long Bound(long count) => Math.Max(count, 0);

        private ItemData InternalAddItem(string itemId, long count) =>
            this.SaveData.Items[itemId] = new ItemData(itemId, this.Bound(count));
    }
}
