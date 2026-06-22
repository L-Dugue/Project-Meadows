using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MarketBuyLogic : MonoBehaviour
{
    [SerializeField] MarketSelectItemsLogic marketSelectItemsLogic;
    [SerializeField] Transform[] boughtItemSlots;
    [SerializeField] private Tilemap tileMapWhichIsPlaceable;
    [SerializeField] private Player player;

    public void SpawnBoughtItem() 
    {
        if(marketSelectItemsLogic.CurrentlySelectedItem._ItemTile != null) 
        {
            foreach(Transform itemSlot in boughtItemSlots) 
            { 
                Vector3Int cellPos = tileMapWhichIsPlaceable.WorldToCell(itemSlot.position); 
                
                if(tileMapWhichIsPlaceable.GetTile(cellPos) == null && (player.PlayerGems - marketSelectItemsLogic.CurrentlySelectedItem._ItemPrice) >= 0)
                {
                    tileMapWhichIsPlaceable.SetTile(cellPos, marketSelectItemsLogic.CurrentlySelectedItem._ItemTile);
                    player.UpdatePlayerGems(marketSelectItemsLogic.CurrentlySelectedItem._ItemPrice);
                    return;
                }
            }
            
            
        }
    }
}
