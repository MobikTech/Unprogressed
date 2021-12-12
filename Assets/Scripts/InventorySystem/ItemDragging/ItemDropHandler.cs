using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unprogressed.Inventory
{
    public class ItemDropHandler : MonoBehaviour, IDropHandler
    {
        private SlotInfo _slotInfo;
    
        private void Start() => _slotInfo = GetComponent<SlotInfo>();

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null ||
                !eventData.pointerDrag.TryGetComponent(out ItemDragHandler draggedObject)) return;
            if(_slotInfo.IsEmpty)
            {
                _slotInfo.AddItem(draggedObject.GetComponent<SlotInfo>().DropItem());
            }
            else
            {
                draggedObject.GetComponent<SlotInfo>().SwapItems(_slotInfo);
            }
            Debug.Log("ondrop");
        }
    }
}

