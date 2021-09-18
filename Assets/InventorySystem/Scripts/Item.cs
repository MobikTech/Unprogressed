using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    public class Item
    {
        public int ID { get; set; }
        public ItemAsset ItemInfo { get; set; }
        public int Amount { get; set; }

        public Item(ItemAsset itemInfo)
        {
            ItemInfo = itemInfo;
        }
    }
}
