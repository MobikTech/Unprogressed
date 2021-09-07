using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unprogressed.Inventory
{
    public class Inventory
    {
        private Dictionary<int, Item> _items;
        private Image[] _slots;

        public Inventory()
        {
            ///Change finding method of item panel slots to method without byName finding
            _slots = Common.UI.MainCanvas.transform.Find("ItemPanel").Find("Background").GetComponentsInChildren<Image>();
            
            _items = new Dictionary<int, Item>();
        }
        public void AddItem(int id, Item item)
        {
            if (_items.ContainsKey(id))
            {
                _items[id].Amount += item.Amount;
            }
            else
            {
                _items.Add(id, item);
            }
            ChangeSlot(item, 0);
        }
        public void DropItem(Item item)
        {
            _items.Remove(item.ItemInfo.ID);
        }
        public void DropItem(Item item, int amount)
        {
            if (amount >= _items[item.ItemInfo.ID].Amount)
            {
                _items.Remove(item.ItemInfo.ID);
            }
            else
            {
                _items[item.ItemInfo.ID].Amount -= amount;
            }
        }

        private void ChangeSlot(Item item, int slot)
        {
            _slots[slot].sprite = item.ItemInfo.Icon;
        }
    }
}
