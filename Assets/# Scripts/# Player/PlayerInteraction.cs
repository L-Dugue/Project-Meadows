using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float _interactionRange = 0.5f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private PlayerInventory _inventory;

    [Header("TileSet Settings")]
    // Serialized Fields
    [SerializeField] private Tilemap worldTileMap;


    

    public void Interact()
    {
        Collider2D contact = Physics2D.OverlapCircle(transform.position, _interactionRange, _interactableLayer);

        if(contact != null) 
        {
            // Interact with item
            if(contact.TryGetComponent<Item>(out Item pickableItem)) 
            {
                // Checks to see if Adding the Item to the Inventory worked
                if (_inventory.AddItemToInventory(pickableItem.itemBluePrint))
                {
                    RemoveItemFromTileSet(contact.gameObject);
                    return;
                }
            }

            if(contact.transform.parent.TryGetComponent<MarketInteraction>(out MarketInteraction market))
            {
                market.EnterMarket();
                return;
            }
        }
    }

    public void HarvestItem()
    {
        Collider2D contact = Physics2D.OverlapCircle(transform.position, _interactionRange, _interactableLayer);

        if (contact != null)
        {
            // Interact with item
            if (contact.TryGetComponent<IHarvestable>(out IHarvestable pickableItem))
            {
                // Checks to see if Adding the Item to the Inventory worked
                if (_inventory.AddItemToInventory(pickableItem.HarvestItem()))
                {
                    return;
                }
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }

    private void RemoveItemFromTileSet(GameObject obj)
    {
        Destroy(obj);
    }
}
