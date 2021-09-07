using System;
using UnityEngine;

namespace Unprogressed.Inventory
{
    public class Item
    {
        public ItemAsset ItemInfo { get; set; }
        //private ItemType _type;
        //private bool _isStackable = false;
        public int Amount { get; set; }
        public Item(ItemAsset itemInfo)
        {
            ItemInfo = itemInfo;
        }
    }
}
