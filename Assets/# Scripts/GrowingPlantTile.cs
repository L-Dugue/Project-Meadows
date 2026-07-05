using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "GrowingPlantTile", menuName = "Custom Tiles")]
public class GrowingPlantTile : Tile
{
    [SerializeField] private Sprite _currentSprite;

    //private TileData _tileData;
    private ITilemap _tileMap;
    private Vector3Int _tilePos;

    // Called when the tile is placed or refreshed
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        //_tileData = tileData;
        _tileMap = tilemap;
        //_tilePos = position;


        base.GetTileData(position, tilemap, ref tileData);

        if (_currentSprite != null)
            tileData.sprite = _currentSprite;
    }

    public void ChangeSprite(Sprite sprite) 
    {
        _currentSprite = sprite;
        _tileMap.RefreshTile(_tilePos);
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        return base.StartUp(position, tilemap, go);
    }
}
