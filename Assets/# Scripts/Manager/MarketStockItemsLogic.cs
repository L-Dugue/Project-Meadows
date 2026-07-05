using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketStockItemsLogic : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Image[] buttons;
    
    // Dictionary Containing the Items for each Market slot
    private Dictionary<Image, Item> marketItems = new Dictionary<Image, Item>();

    private void Start()
    {
        foreach(Image button in buttons)
        {
            // Grabs random Item
            Item randomItem = items[Random.Range(0, items.Length)];

            // If the marketItems dict already contains that item, generate another.
            while (marketItems.ContainsValue(randomItem)) 
            {
                randomItem = items[Random.Range(0, items.Length)];
            }

            // Add the item to the MarketItems
            marketItems.Add(button, randomItem);
            ItemBluePrint itemDetails = randomItem.itemBluePrint;

            // update the Market's Sprites
            button.sprite = itemDetails._ImageSprite;
        }
    }

    public Dictionary<Image, Item> ItemsInStock() => marketItems;
}
