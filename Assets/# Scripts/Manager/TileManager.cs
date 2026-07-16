using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Yarn;


public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }

    [Header("Tilemap Placement Settings")]
    [SerializeField] private Tilemap pickupTileMap;
    [SerializeField] private Tilemap enviromentTileMap;

    [Header("Placeable Tiles Lists")]
    [SerializeField] private PlaceableTilesList flowerPlaceableTiles;

    [Header("Player Scripts")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerInventory playerInv;

    [Header("Item Check Settings")]
    [SerializeField] private float _interactionRange = 1.0f;
    [SerializeField] private LayerMask _interactableLayer;


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

    public bool IsEmptyOfItemViaMousePos(Vector2 mousePos)
    {
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position

        Collider2D contact = Physics2D.OverlapCircle(new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), _interactionRange, _interactableLayer);


        if (contact == null)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool IsEmptyOfItemViaMousePos<ItemToIgnore>(Vector2 mousePos, out ItemToIgnore itemToIgnoreReturned) where ItemToIgnore : Component
    {
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position

        Collider2D contact = Physics2D.OverlapCircle(new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), _interactionRange, _interactableLayer);

        // Checks to see if the spot is NULL, or if it has an item that can ignored. Else the item can NOT be placed.
        if (contact == null)
        {
            itemToIgnoreReturned = null;
            return true;
        }
        else if(contact.TryGetComponent<ItemToIgnore>(out ItemToIgnore val))
        {
            itemToIgnoreReturned = contact.GetComponent<ItemToIgnore>();
            return true;
        }
        else
        {
            itemToIgnoreReturned = null;
            return false;
        }

    }

    public bool IsEmptyOfItemViaMousePos<ItemToIgnore>(Vector2 mousePos) where ItemToIgnore : Component
    {
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position

        Collider2D contact = Physics2D.OverlapCircle(new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), _interactionRange, _interactableLayer);

        if (contact == null || contact.TryGetComponent<ItemToIgnore>(out ItemToIgnore val))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool IsEmptyOfItemViaPosition(Vector2 pos)
    {
        Vector3Int cellPos = pickupTileMap.WorldToCell(pos); // Finds the grid which matches the position
        Collider2D contact = Physics2D.OverlapCircle(new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), _interactionRange, _interactableLayer);


        if (contact == null)
        {
            return true;
        }
        else
        {
            return false;
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

    public void PlacingItemViaMousePos(GameObject itemObj, Vector2 mousePos)
    {
        Debug.Log("Placing Item");
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position
        GameObject item = Instantiate(itemObj, new Vector3(pickupTileMap.GetCellCenterWorld(cellPos).x, pickupTileMap.GetCellCenterWorld(cellPos).y, 0), Quaternion.identity);

        item.transform.parent = pickupTileMap.transform;
    }

    public void PlacingItemViaPosition(GameObject itemObj, Vector2 pos)
    {
        Vector3Int cellPos = pickupTileMap.WorldToCell(pos); // Finds the grid which matches the position
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

    /// <summary>
    /// Replace Object One with Object Two.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="ObjOne"></param>
    /// <param name="ObjTwo"></param>
    public void ReplaceItems(Vector3 pos, GameObject ObjOne, GameObject ObjTwo)
    {
        GameObject item = Instantiate(ObjTwo, pos, Quaternion.identity);
        item.transform.parent = pickupTileMap.transform;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }

}
