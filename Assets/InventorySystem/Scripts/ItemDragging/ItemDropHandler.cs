using UnityEngine;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    public class ItemDropHandler : MonoBehaviour, IDropHandler
    {
        private RectTransform _rectTransform;
    
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        public void OnDrop(PointerEventData eventData)
        {
            print("OnDrop");
            if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<ItemDragHandler>(out ItemDragHandler draggedObject))
            {
                draggedObject.SetActualParent();
                transform.localPosition = Vector3.zero;
                draggedObject.Alpha = 1f;
                
                eventData.pointerDrag.GetComponent<RectTransform>().position = _rectTransform.position;
            }
        }
    }
}

