using UnityEngine;
using UnityEngine.UI;
using Unprogressed.Common;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    public class Inventory
    {
        private const int _panelSlotAmount = 10;
        private SlotInfo[] _slots;

        public Inventory() => InitializeInventory();
        
        //todo
        /// <summary>
        /// Change finding method of item panel slots to method without byName finding
        /// </summary>
        private void InitializeInventory() => _slots = UI.MainCanvas.transform.Find("ItemPanel").GetComponentsInChildren<SlotInfo>();

        public bool TryAddItem(Item item)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    _slots[i].AddItem(item);
                    return true;
                }
            }
            return false;
        }
        public Item DropItem(int slotNum) => _slots[slotNum].DropItem();
        public Item DropItem(SlotInfo slotInfo) => slotInfo.DropItem();
        //public void DropItem(Item item, int amount)
        //{
        //    if (amount >= _items[item.ItemInfo.ID].Amount)
        //    {
        //        _items.Remove(item.ItemInfo.ID);
        //    }
        //    else
        //    {
        //        _items[item.ItemInfo.ID].Amount -= amount;
        //    }
        //}

        //private void ChangeSlot(Item item, int slot)
        //{
        //    _slots[slot].sprite = item.ItemInfo.Icon;
        //}
    }
}
