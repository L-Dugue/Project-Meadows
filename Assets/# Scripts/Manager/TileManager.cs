using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
    //    [Header("ScanZone Bounds")]
    //    private Bounds _scanZone;
    //    [SerializeField] private Vector2 min; // Defining Min
    //    [SerializeField] private Vector2 max; // Defining Max

    // MAKE INTO SINGLETON!
    public static TileManager Instance { get; private set; }

    [Header("Tilemap Placement Settings")]
    [SerializeField] private Tilemap pickupTileMap;
    [SerializeField] private Tilemap enviromentTileMap;

    [Header("Placeable Tiles Lists")]
    [SerializeField] private PlaceableTilesList flowerPlaceableTiles;

    [Header("Player Scripts")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerInventory playerInv;


    private void Awake()
    {
       if(Instance != null && Instance != this)
       {
            Destroy(this);
       }
        else
        {
            Instance = this;
        }
        
    }


    private bool IsOnValidPlaceableTile(ItemBluePrint[] _items,int index)
    {

        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(player.MousePos);
        Vector3Int cellPos = pickupTileMap.WorldToCell(mouseInWorldSpace);

        switch (_items[index]?._ItemObj.GetComponent<Item>())
        {
            case Flower:
                if (flowerPlaceableTiles.PlaceableTiles.Contains((Tile)enviromentTileMap.GetTile(cellPos)))
                {
                    return true;
                }
                else
                {
                    return false;
                }



            case Seeds:
            case FlowerPotWithSeeds:
            case FlowerInFlowerPot:
            case FlowerPot:
                if (pickupTileMap.GetTile(cellPos) == null)
                {
                    Debug.Log("PLACING");
                    return true;
                }
                else
                {
                    return false;
                }



            default: return false;
        }


    }




    private bool IsMouseInPlacementRange()
    {
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(player.MousePos);
        if (Mathf.Pow((mouseInWorldSpace.x - player.transform.position.x), 2) + Mathf.Pow((mouseInWorldSpace.y - player.transform.position.y), 2) < Mathf.Pow(playerInv.PlacementRange, 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlacingItem(GameObject itemObj, Vector2 mousePos)
    {
        Debug.Log("Placing Item");
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position
        GameObject item = Instantiate(itemObj, new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), Quaternion.identity);

        item.transform.parent = pickupTileMap.transform;
    }

    /// <summary>
    /// Places an Item into the world. Will delete the Object which called this method.
    /// </summary>
    /// <param name="itemObj"></param>
    /// <param name="pos"></param>
    /// <param name="originalObj"></param>
    public void CombindItems(GameObject itemObj, Vector3 pos, GameObject ObjOne, GameObject ObjTwo)
    {
        GameObject item = Instantiate(itemObj, pos, Quaternion.identity);
        item.transform.parent = pickupTileMap.transform;
        Destroy(ObjTwo);
        Destroy(ObjOne);
    }


    public bool CheckIfPlaceable(ItemBluePrint[] _items, int index)
    {
        if (IsMouseInPlacementRange() && IsOnValidPlaceableTile(_items, index))
        {
            return true;
        }
        return false;
    }


   






    //private void Awake()
    //{
    //    PickupTileMap = _pickupTileMap;

    //    _scanZone.center = transform.position;
    //    _scanZone.min = min;
    //    _scanZone.max = max;

    //    PopulateTileWithGameObjects();
    //}

    //public static void ChangeTileTo(Tile tile, Transform pos)
    //{
    //    Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
    //    GameObject originalObj = PickupTileMap.GetInstantiatedObject(cellPos);

    //    PickupTileMap.SetTile(cellPos, tile);

    //}

    //public static void ChangeTileSpriteTo(Sprite sprite, Transform pos)
    //{
    //    Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
    //    TileBase tileAtPos = PickupTileMap.GetTile(cellPos);

    //    if(tileAtPos is GrowingPlantTile growingPlantTile)
    //    {
    //        Debug.Log("RAN");
    //        growingPlantTile.ChangeSprite(sprite);
    //    }
    //}

    //public static void RefreshTileAtPos(Transform pos)
    //{
    //    Vector3Int cellPos = PickupTileMap.WorldToCell(pos.position);
    //    TileBase tileAtPos = PickupTileMap.GetTile(cellPos);
    //    Debug.Log(tileAtPos.name);
    //    tileAtPos.RefreshTile(cellPos, PickupTileMap);
    //}


    //private void PopulateTileWithGameObjects()
    //{
    //    for (int x = (int)_scanZone.min.x; x < _scanZone.max.x; x++)
    //    {
    //        for (int y = (int)_scanZone.min.y; y < _scanZone.max.y; y++)
    //        {
    //            Vector3Int pos = new(x, y, 0);

    //            if (_pickupTileMap.GetTile(pos) is GrowingPlantTile tile)
    //            {
    //                Debug.Log(tile.name);
    //            }
    //        }
    //    }
    //}

    //void OnDrawGizmos()
    //{
    //    _scanZone.min = min;
    //    _scanZone.max = max;
    //    _scanZone.center = transform.position;


    //    Gizmos.DrawWireCube(_scanZone.center, _scanZone.size);
    //    Gizmos.color = Color.hotPink;
    //}

}
