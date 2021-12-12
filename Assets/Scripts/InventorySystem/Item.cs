using System;

namespace Unprogressed.Inventory
{
    public class Item
    {
        public ItemAsset ItemInfo { get; set; }
        public int Amount { get; set; }

        public Item(ItemAsset itemInfo) => ItemInfo = itemInfo;
    }
}
