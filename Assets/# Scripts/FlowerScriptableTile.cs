using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "Flower", menuName = "FlowerTile")]
public class FlowerScriptableTile : Tile
{
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }


}
