using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventorySlotLogic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 mousePos;
    private Vector3 originalPos;
    private Transform originalParent;

    private void Awake()
    {
        originalPos = GetComponent<RectTransform>().localPosition;
        originalParent = GetComponent<RectTransform>().parent;
    }

    public void OnUICursorPos(InputAction.CallbackContext context) 
    {
        mousePos = context.ReadValue<Vector2>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("Stop Drag");
       GetComponent<RectTransform>().localPosition = originalPos;
       GetComponent<RectTransform>().SetParent(originalParent);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Began Hovering");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Stopped Hovering");
    }
}
