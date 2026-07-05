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
    private ItemBluePrint currentlySelectedItemInBuy;
    private ItemBluePrint currentlySelectedItemInSell;

    // Public Properties
    public ItemBluePrint CurrentlySelectedItemInBuy {  get { return currentlySelectedItemInBuy; } }
    public ItemBluePrint CurrentlySelectedItemInSell { get { return currentlySelectedItemInSell; } }


    public void OnMarketItemSelectedInBuy(Image itemSlotSelected) 
    {
        itemsInStock = stockedItems.ItemsInStock();
        DisplayItemDetails(itemsInStock[itemSlotSelected].itemBluePrint);
        currentlySelectedItemInBuy = itemsInStock[itemSlotSelected].itemBluePrint;
    }

    public void OnMarketItemselectedInSell(Image itemSlotSelected) 
    {
        
        foreach(Item item in itemsAbledToBeSold) 
        {
            if (item.itemBluePrint._ImageSprite == itemSlotSelected.sprite)
            {
                currentlySelectedItemInSell = item.itemBluePrint;
                break;
            }
        }

        DisplayItemDetails(currentlySelectedItemInSell);
    }

    private void DisplayItemDetails(ItemBluePrint itemData) 
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
