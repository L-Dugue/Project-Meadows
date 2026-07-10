using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flower : Item, IPlaceableOnItem
{
    [Header("Variant of Flower In Pots")]
    [SerializeField] private UseableFlowerPots useableFlowerPots;

    [Header("Interaction Settings")]
    [SerializeField] private float _interactionRange = 1.0f;
    [SerializeField] private LayerMask _interactableLayer;



    private void Awake()
    {
        PlaceOnItem();
    }

    public void PlaceOnItem()
    {
        Collider2D[] contacts = Physics2D.OverlapCircleAll(transform.position, _interactionRange, _interactableLayer);

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
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }


}
