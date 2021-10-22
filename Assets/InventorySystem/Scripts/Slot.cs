using UnityEngine.UI;
using UnityEngine;

namespace Unprogressed.Inventory
{
    public class Slot
    {
        private Image _image;
        private Item _item;

        public Item Item => _item;
        public Image Image => _image;

        public Slot(Image imageOnUI)
        {
            _image = imageOnUI;
            ResetImage();
        }
        public void ChangeItem(Item item)
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
        public void SwapItems(Slot slot)
        {
            Item thisItem = this._item;
            Image thisImage = this._image;

            this._item = slot._item;
            slot._item = thisItem;

            this._image = slot._image;
            slot._image = thisImage;
        }
        private void ResetImage()
        {
            _image.sprite = null;
            _image.color = Color.clear;
        }
    }
}
