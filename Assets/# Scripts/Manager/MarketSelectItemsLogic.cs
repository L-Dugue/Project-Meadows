using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketSelectItemsLogic : MonoBehaviour
{
    [Header("Text Boxes to Fill")]
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDesc;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemPrice;

    [Header("Other Scripts")]
    [SerializeField] private MarketStockItemsLogic stockedItems;


    // Private Variables
    private Dictionary<Image, Item> itemsInStock = new Dictionary<Image, Item>();


    public void OnMarketItemSelected(Image itemSlotSelected) 
    {
        itemsInStock = stockedItems.ItemsInStock();

        if (itemsInStock[itemSlotSelected] is Flower) { DisplayItemDetails(itemsInStock[itemSlotSelected].ReturnItemData(), true); }      
        else { DisplayItemDetails(itemsInStock[itemSlotSelected].ReturnItemData(), false); }


    }


    private void DisplayItemDetails(ItemData itemData, bool hasType) 
    {
        itemName.text = itemData._Name;
        itemDesc.text = itemData._Description;
        itemPrice.text = "999";

        if (hasType) { itemType.text = itemData._FlowerType; }

    }
}
