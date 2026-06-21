using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
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
    private Tile currentlySelectedItem;

    // Public Properties
    public Tile CurrentlySelectedItem {  get { return currentlySelectedItem; } }


    public void OnMarketItemSelected(Image itemSlotSelected) 
    {
        itemsInStock = stockedItems.ItemsInStock();
        DisplayItemDetails(itemsInStock[itemSlotSelected].ReturnItemData());
        currentlySelectedItem = itemsInStock[itemSlotSelected].ReturnItemData()._ItemTile;
    }


    private void DisplayItemDetails(ItemData itemData) 
    {
        itemName.text = itemData._Name;
        itemDesc.text = itemData._Description;
        itemPrice.text = itemData._ItemPrice.ToString();
        itemType.text = itemData._ItemRarity; 
    }
}
