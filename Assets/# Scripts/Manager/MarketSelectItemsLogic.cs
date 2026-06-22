using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MarketSelectItemsLogic : MonoBehaviour
{
    [Header("Text Boxes to Fill")]
    [SerializeField] private TextMeshProUGUI[] itemNames;
    [SerializeField] private TextMeshProUGUI[] itemDesc;
    [SerializeField] private TextMeshProUGUI[] itemRarity;
    [SerializeField] private TextMeshProUGUI[] itemPrice;

    [Header("Other Scripts")]
    [SerializeField] private MarketStockItemsLogic stockedItems;

    [Header("All Items available to Sell")]
    [SerializeField] private Item[] itemsAbledToBeSold;


    // Private Variables
    private Dictionary<Image, Item> itemsInStock = new Dictionary<Image, Item>();
    private Tile currentlySelectedItem;
    private ItemData selectedItem;

    // Public Properties
    public Tile CurrentlySelectedItem {  get { return currentlySelectedItem; } }


    public void OnMarketItemSelectedInBuy(Image itemSlotSelected) 
    {
        itemsInStock = stockedItems.ItemsInStock();
        DisplayItemDetails(itemsInStock[itemSlotSelected].ReturnItemData());
        currentlySelectedItem = itemsInStock[itemSlotSelected].ReturnItemData()._ItemTile;
    }

    public void OnMarketItemselectedInSell(Image itemSlotSelected) 
    {
        
        foreach(Item item in itemsAbledToBeSold) 
        {
            if(item.ReturnItemData()._ImageSprite == itemSlotSelected.sprite)
            {
                selectedItem = item.ReturnItemData();
                break;
            }
        }

        DisplayItemDetails(selectedItem);
    }

    private void DisplayItemDetails(ItemData itemData) 
    {
        // Iterates through names
        foreach(TextMeshProUGUI itemName in itemNames)
        {
            itemName.text = itemData._Name;
        }

        // Iterates through Descs
        foreach (TextMeshProUGUI itemDesc in itemDesc)
        {
            itemDesc.text = itemData._Description;
        }

        // Iterates through Prices
        foreach (TextMeshProUGUI itemPrice in itemPrice)
        {
            itemPrice.text = itemData._ItemPrice.ToString();
        }

        // Iterates through Rarities
        foreach (TextMeshProUGUI itemRarity in itemRarity)
        {
            itemRarity.text = itemData._ItemRarity;
        }



       
    }
}
