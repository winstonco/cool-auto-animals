using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : Item
{
    /// <summary>
    /// Default constructor. Creates a new ShopItem.
    /// </summary>
    public ShopItem()
    {

    }
    public class DragDroppable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas canvas;

        private RectTransform rt;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            rt.anchoredPosition += eventData.delta / canvas.scaleFactor;

        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}
