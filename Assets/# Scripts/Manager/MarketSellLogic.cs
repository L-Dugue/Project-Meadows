using System;
using UnityEngine;
using UnityEngine.Events;

public class MarketSellLogic : MonoBehaviour
{
    [SerializeField] private MarketSelectItemsLogic ItemsSelectLogic;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerCurrency playerCurrency;
    [SerializeField] private InventoryUI inventoryUI;


    [SerializeField] private UnityEvent OnItemSold;

    public void SellItem()
    {
        Debug.Log("RAN");
        if (playerInventory.RemoveItemFromInventory(ItemsSelectLogic.CurrentlySelectedItemInSell))
        {
            inventoryUI.RemoveItem(ItemsSelectLogic.CurrentlySelectedItemInSell);
            playerCurrency.SellItem((int)(ItemsSelectLogic.CurrentlySelectedItemInSell._ItemPrice/2));
        }

    }
}
