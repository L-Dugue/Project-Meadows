using System;
using UnityEngine;
using UnityEngine.Events;

public class MarketSellLogic : MonoBehaviour
{
    [SerializeField] private MarketSelectItemsLogic m_ItemsSelectLogic;
    [SerializeField] private PlayerInventory m_playerInventory;
    [SerializeField] private Player m_player;
    [SerializeField] private InventoryUI m_InventoryUI;


    [SerializeField] private UnityEvent OnItemSold;

    public void SellItem()
    {
        Debug.Log("RAN");
        if (m_playerInventory.RemoveItemFromInventory(m_ItemsSelectLogic.CurrentlySelectedItemInSell))
        {
            m_InventoryUI.RemoveItem(m_ItemsSelectLogic.CurrentlySelectedItemInSell);

            // Convert to C# event.
            m_player.PlayerGems += m_ItemsSelectLogic.CurrentlySelectedItemInSell._ItemPrice; 
        }
        
    }
}
