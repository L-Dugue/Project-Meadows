using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MarketBuyLogic : MonoBehaviour
{
    [SerializeField] MarketSelectItemsLogic marketSelectItemsLogic;
    [SerializeField] Transform[] boughtItemSlots;
    [SerializeField] private Tilemap tileMapWhichIsPlaceable;
    [SerializeField] private PlayerCurrency playerCurrency;

    public void SpawnBoughtItem() 
    {
        // If Statement to check if the specific tile houses an object or not.
            foreach (Transform itemSlot in boughtItemSlots)
            {
                if (!TileManager.Instance.IsEmptyOfItemViaPosition(itemSlot.position)) { continue; }

                if ( (playerCurrency.PlayerGems - marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice) >= 0)
                {
                    TileManager.Instance.PlacingItemViaPosition(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemObj, itemSlot.position);
                    playerCurrency.BuyItem(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice);
                    return;
                }
            }
    }
}
