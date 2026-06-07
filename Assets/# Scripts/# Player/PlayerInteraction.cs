using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float _interactionRange = 1.0f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private PlayerInventory _inventory;


    public void PerformPickingUpItem()
    {
        Collider2D contact = Physics2D.OverlapCircle(transform.position, _interactionRange, _interactableLayer);

        if(contact != null) 
        {
            if(contact.TryGetComponent<Item>(out Item pickableItem)) 
            {
                // Checks to see if Adding the Item to the Inventory worked
                if (_inventory.AddItemToInventory(pickableItem.ItemPickedUp()))
                {
                    Destroy(pickableItem.gameObject);
                }

                Debug.Log("Performing pickup");
            }
        }
    }

    public void DEBUGGER()
    {
        _inventory.PrintOutContentsOfInventoryDEBUGGING();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }
}
