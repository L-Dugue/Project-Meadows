using UnityEngine;
using UnityEngine.Tilemaps;

public class Seeds : Item, IPlaceableOnItem
{
    
    [Header("Interaction Settings")]
    [SerializeField] private float _interactionRange = 1.0f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private float _yOffset;

    [Header("Variant of Seeds In Pots")]
    [SerializeField] private UseableFlowerPots useableFlowerPots;

    private void Awake()
    {
        PlaceOnItem();
    }

    public void PlaceOnItem()
    {
        Collider2D[] contacts = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + _yOffset), _interactionRange, _interactableLayer);

        foreach (Collider2D contact in contacts)
        {
            if (contact.gameObject == this.gameObject)
            {
                continue;
            }

            if (contact.TryGetComponent<FlowerPot>(out FlowerPot pot))
            {
                if (useableFlowerPots.FlowerInFlowerPot(pot.itemBluePrint._ItemObj, out GameObject potRecieved))
                {
                    TileManager.Instance.CombindItems(potRecieved, gameObject.transform.position, this.gameObject, contact.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + _yOffset), _interactionRange);
    }

}
