using UnityEngine;
using UnityEngine.Tilemaps;

public class MarketBuyLogic : MonoBehaviour
{
    [SerializeField] MarketSelectItemsLogic marketSelectItemsLogic;
    [SerializeField] Transform[] boughtItemSlots;
    [SerializeField] private Tilemap tileMapWhichIsPlaceable;

    public void SpawnBoughtItem() 
    {
        if(marketSelectItemsLogic.CurrentlySelectedItem != null) 
        {
            foreach(Transform itemSlot in boughtItemSlots) 
            { 
                Vector3Int cellPos = tileMapWhichIsPlaceable.WorldToCell(itemSlot.position); 
                
                if(tileMapWhichIsPlaceable.GetTile(cellPos) == null) 
                {

                    tileMapWhichIsPlaceable.SetTile(cellPos, marketSelectItemsLogic.CurrentlySelectedItem);
                    return;
                }
            }
            

        }
    }
}
