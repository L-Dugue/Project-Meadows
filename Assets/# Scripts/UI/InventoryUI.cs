using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] inventoryImagesPanels;


    // Events
    public delegate void InventoryRemoveItem(int index, Vector2 mousePos);
    public static event InventoryRemoveItem RemoveItemFromInventory;

    // Private Fields
    private Sprite defaultSprite;
    private ItemData?[] itemDatas = new ItemData?[4];


    private void Awake()
    {
        PlayerInventory.OnItemAddedToInventory += UpdateInventoryUI;
        defaultSprite = inventoryImagesPanels[0].GetComponent<Image>().sprite;

    }

    // Public Methods
    public void UpdateInventoryUI(int index, ItemData? item) 
    {
        inventoryImagesPanels[index].sprite = item.Value._ImageSprite;
        itemDatas[index] = item;
    }

    
    public void RemoveItem(int index)
    {
        if (itemDatas[index] != null) 
        {
            Debug.Log("RAN!");
            inventoryImagesPanels[index].sprite = defaultSprite;
            itemDatas[index] = null;
            RemoveItemFromInventory?.Invoke(index, inventoryImagesPanels[index].GetComponent<InventorySlotLogic>().MousePos);
        }
       
    }
}
