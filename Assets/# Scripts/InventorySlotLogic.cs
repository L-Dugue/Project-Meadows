using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventorySlotLogic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Private 
    private Vector2 mousePos;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] int InventoryIndex;

    // Properties
    public Vector2 MousePos { get { return mousePos; } }

    // For Snapping back to original pos.
    private Vector3 originalPos;
    private Transform originalParent;

    // For always being ontop of other slots
    private Transform parentDuringDrag;

    // Flags
    private bool isDragging;


    private void Awake()
    {
        originalPos = GetComponent<RectTransform>().position;
        originalParent = GetComponent<RectTransform>().parent;
    }

    public void OnUICursorPos(InputAction.CallbackContext context) 
    {
        mousePos = context.ReadValue<Vector2>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");

        if(GetComponent<Image>().sprite == null) { return; }

        isDragging = true;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging) 
        {
            Debug.Log("Dragging");
            transform.position = mousePos;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Debug.Log("Stop Drag");
            inventoryUI.RemoveItem(InventoryIndex);
            GetComponent<RectTransform>().position = originalPos;
            GetComponent<RectTransform>().SetParent(originalParent);
            isDragging = false;
        }
            
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
