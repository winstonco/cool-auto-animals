using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/// <summary>
/// This object can be dragged using the mouse.
/// </summary>
public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rt;
    private Vector2 startPos;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), 0) / canvas.scaleFactor;
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        // Check if was dropped in a slot
        Field field = GameObject.Find("Friendly Field").GetComponent<Field>();
        if (field.DroppedInSlot == false)
        {
            transform.position = startPos;
        }
        else
        {
            field.DroppedInSlot = false;
        }
    }
}
