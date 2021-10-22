using UnityEngine;
using UnityEngine.UI;
using Unprogressed.Common;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    public class Inventory
    {
        private const int _panelSlotAmount = 10;
        private Slot[] _slots;

        public Inventory() => InitializeInventory();
        
        //todo
        /// <summary>
        /// Change finding method of item panel slots to method without byName finding
        /// </summary>
        private void InitializeInventory()
        {
            _slots = new Slot[_panelSlotAmount];
            ItemDragHandler[] imageObjectComponents = UI.MainCanvas.transform.Find("ItemPanel").GetComponentsInChildren<ItemDragHandler>();
            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i] = new Slot(imageObjectComponents[i].gameObject.GetComponent<Image>());
            }
        }
        public bool AddItem(Item item)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].Item == null)
                {
                    _slots[i].ChangeItem(item);
                    return true;
                }
            }
            return false;
        }
        public Item DropItem(int slotNum) => _slots[slotNum].DropItem();
        public Item DropItem(Slot slot) => slot.DropItem();
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
