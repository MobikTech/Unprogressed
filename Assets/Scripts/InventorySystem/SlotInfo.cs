using UnityEngine.UI;
using UnityEngine;

namespace Unprogressed.Inventory
{
    public class SlotInfo : MonoBehaviour
    {
        private Image _image;
        private Item _item;
        public bool IsEmpty => _item == null;
        
        
        public void Awake()
        {
            _image = GetComponent<Image>();
            ResetImage();
        }

        public void AddItem(Item item)
        {
            _item = item;
            _image.color = Color.white;
            _image.sprite = item.ItemInfo.Icon;
        }
        public Item DropItem()
        {
            Item item = _item;
            _item = null;
            ResetImage();
            return item;
        }
        public void SwapItems(SlotInfo slotInfo)
        {
            Item tempItem = _item;
            ChangeItem(slotInfo._item);
            slotInfo.ChangeItem(tempItem);
            Debug.Log("swap");
        }

        private void ChangeItem(Item item)
        {
            _item = item;
            _image.color = Color.white;
            _image.sprite = _item.ItemInfo.Icon;
        }
        private void ResetImage()
        {
            _image.sprite = null;
            _image.color = Color.clear;
        }
    }
}
