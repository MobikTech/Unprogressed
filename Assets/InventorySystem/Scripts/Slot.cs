using UnityEngine.UI;

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
            //_image.sprite = Common.ItemGenerator.ItemInfoList[ItemType.None].Icon;
        }
        public void ChangeItem(Item item)
        {
            _item = item;
            _image.sprite = item.ItemInfo.Icon;
        }
        public Item DropItem()
        {
            Item item = _item;
            _item = null;
            ResetImage();
            //_image.sprite = Common.ItemGenerator.ItemInfoList[ItemType.None].Icon;
            return item;
        }
        private void ResetImage()
        {
            _image.sprite = null;
        }
    }
}
