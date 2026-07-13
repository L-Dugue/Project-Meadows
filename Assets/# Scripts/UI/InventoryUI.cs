using System;
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
    private ItemBluePrint?[] itemDatas = new ItemBluePrint?[4];


    private void Awake()
    {
        PlayerInventory.OnItemAddedToInventory += UpdateInventoryUI;
        defaultSprite = inventoryImagesPanels[0].GetComponent<Image>().sprite;

    }

    // Public Methods
    public void UpdateInventoryUI(int index, ItemBluePrint? item) 
    {
        inventoryImagesPanels[index].sprite = item._ImageSprite;
        itemDatas[index] = item;
    }

    
    public void RemoveItem(int index)
    {
        if (itemDatas[index] != null) 
        {
            inventoryImagesPanels[index].sprite = defaultSprite;
            itemDatas[index] = null;
            RemoveItemFromInventory?.Invoke(index, inventoryImagesPanels[index].GetComponent<InventorySlotLogic>().InventoryMousePos);
        }
       
    }

    public void RemoveItem(ItemBluePrint item)
    {
        int panelToMakeDefaultIndex = 0;

       for(int i = 0; i < inventoryImagesPanels.Length; i++)
       {
            if(inventoryImagesPanels[i].sprite == item._ImageSprite)
            {
                panelToMakeDefaultIndex = i;
                break;
            }
       }

        foreach (ItemBluePrint? itemData in itemDatas)
        {
            if (itemData != null && (itemData?._Name == item._Name))
            {
                inventoryImagesPanels[panelToMakeDefaultIndex].sprite = defaultSprite;
                itemDatas[Array.IndexOf(itemDatas, itemData)] = null;
                break;
            }
        }

        //if (itemDatas[index] != null)
        //{
        //    inventoryImagesPanels[index].sprite = defaultSprite;
        //    itemDatas[index] = null;
        //    RemoveItemFromInventory?.Invoke(index, inventoryImagesPanels[index].GetComponent<InventorySlotLogic>().InventoryMousePos);
        //}

    }
}
