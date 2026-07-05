using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
    [Header("ScanZone Bounds")]
    private Bounds _scanZone;
    [SerializeField] private Vector2 min; // Defining Min
    [SerializeField] private Vector2 max; // Defining Max

    // MAKE INTO SINGLETON!

    [SerializeField] private Tilemap _pickupTileMap;
    private static Tilemap PickupTileMap;

    private void Awake()
    {
        PickupTileMap = _pickupTileMap;

        _scanZone.center = transform.position;
        _scanZone.min = min;
        _scanZone.max = max;

        PopulateTileWithGameObjects();
    }

    public static void ChangeTileTo(Tile tile, Transform pos)
    {
        Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
        GameObject originalObj = PickupTileMap.GetInstantiatedObject(cellPos);

        PickupTileMap.SetTile(cellPos, tile);

    }

    public static void ChangeTileSpriteTo(Sprite sprite, Transform pos)
    {
        Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
        TileBase tileAtPos = PickupTileMap.GetTile(cellPos);

        if(tileAtPos is GrowingPlantTile growingPlantTile)
        {
            Debug.Log("RAN");
            growingPlantTile.ChangeSprite(sprite);
        }
    }

    public static void RefreshTileAtPos(Transform pos)
    {
        Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
        TileBase tileAtPos = PickupTileMap.GetTile(cellPos);
        Debug.Log(tileAtPos.name);
        tileAtPos.RefreshTile(cellPos, PickupTileMap);
    }


    private void PopulateTileWithGameObjects()
    {
        for (int x = (int)_scanZone.min.x; x < _scanZone.max.x; x++)
        {
            for (int y = (int)_scanZone.min.y; y < _scanZone.max.y; y++)
            {
                Vector3Int pos = new(x, y, 0);

                if (_pickupTileMap.GetTile(pos) is GrowingPlantTile tile)
                {
                    Debug.Log(tile.name);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        _scanZone.min = min;
        _scanZone.max = max;
        _scanZone.center = transform.position;


        Gizmos.DrawWireCube(_scanZone.center, _scanZone.size);
        Gizmos.color = Color.hotPink;
    }

}
