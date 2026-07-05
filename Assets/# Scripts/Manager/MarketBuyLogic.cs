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
                Vector3Int cellPos = tileMapWhichIsPlaceable.WorldToCell(itemSlot.position);

                if ((playerCurrency.PlayerGems - marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice) >= 0)
                {
                    Instantiate(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemObj, new Vector3(tileMapWhichIsPlaceable.GetCellCenterWorld(cellPos).x, tileMapWhichIsPlaceable.GetCellCenterWorld(cellPos).y, 0), Quaternion.identity);
                    playerCurrency.BuyItem(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice);
                    return;
                }
            }
    }
}
