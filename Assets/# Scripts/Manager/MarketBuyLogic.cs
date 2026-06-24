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
        if(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemTile != null) 
        {
            foreach(Transform itemSlot in boughtItemSlots) 
            { 
                Vector3Int cellPos = tileMapWhichIsPlaceable.WorldToCell(itemSlot.position); 
                
                if(tileMapWhichIsPlaceable.GetTile(cellPos) == null && (playerCurrency.PlayerGems - marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice) >= 0)
                {
                    tileMapWhichIsPlaceable.SetTile(cellPos, marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemTile);
                    playerCurrency.BuyItem(marketSelectItemsLogic.CurrentlySelectedItemInBuy._ItemPrice);
                    return;
                }
            }
            
            
        }
    }
}
