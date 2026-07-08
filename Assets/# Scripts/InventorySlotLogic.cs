using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InventorySlotLogic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Private 
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] int InventoryIndex;
    [SerializeField] Player player;
    private Vector2 inventoryMousePos;

    // For Snapping back to original pos.
    private Vector3 originalPos;
    private Transform originalParent;

    // For always being ontop of other slots
    private Transform parentDuringDrag;

    // Flags
    private bool isDragging;

    // Public Properties
    public Vector2 InventoryMousePos { get { return inventoryMousePos; } set { inventoryMousePos = value; } }


    private void Awake()
    {
        originalPos = GetComponent<RectTransform>().position;
        originalParent = GetComponent<RectTransform>().parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GetComponent<Image>().sprite == null) { return; }

        isDragging = true;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging) 
        {
            InventoryMousePos = player.MousePos;
            transform.position = player.MousePos;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Checks to ensure that the item CAN be placed in the world before removing from Inventory.
        if (isDragging && TileManager.Instance.CheckIfPlaceable(player.gameObject.GetComponent<PlayerInventory>().Items, InventoryIndex))
        {
            inventoryUI.RemoveItem(InventoryIndex);
            player.gameObject.GetComponent<PlayerInventory>().RemoveItemFromInventory(InventoryIndex, player.MousePos);
        }

        GetComponent<RectTransform>().position = originalPos;
        GetComponent<RectTransform>().SetParent(originalParent);
        isDragging = false;

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
