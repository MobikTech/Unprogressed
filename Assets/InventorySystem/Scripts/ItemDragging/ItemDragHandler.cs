using UnityEngine;
using UnityEngine.EventSystems;

namespace Unprogressed.Inventory
{
    internal class ItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Transform _cachedParent;
        private Transform _actualParent;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _actualParent = transform.parent;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0.6f;
            transform.SetParent(_cachedParent);
        }
        
        public void OnDrag(PointerEventData eventData) => _rectTransform.position = Input.mousePosition;
        
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_actualParent);
            transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1f;
        }
    }
}
