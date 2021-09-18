using UnityEngine;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    internal class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            //transform.position = Input.mousePosition;
            gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
