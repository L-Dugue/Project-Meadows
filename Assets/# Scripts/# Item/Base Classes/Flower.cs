using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flower : Item
{
    [Header("Variant of Flower In Pots")]
    [SerializeField] private UseableFlowerPots useableFlowerPots;

    [Header("Interaction Settings")]
    [SerializeField] private float _interactionRange = 1.0f;
    [SerializeField] private LayerMask _interactableLayer;


    private void Update()
    {
        CheckIfPlacedOnFlowerPot();
    }

    private void CheckIfPlacedOnFlowerPot()
    {
        Collider2D contact = Physics2D.OverlapCircle(transform.position, _interactionRange, _interactableLayer);

        if (contact.TryGetComponent<FlowerPot>(out FlowerPot pot))
        {

            //if(useableFlowerPots.FlowerInFlowerPot(pot.itemBluePrint._ItemObj, out GameObject potRecieved))
            //{
            //    TileManager.Instance.PlacingItem(potRecieved, gameObject.transform, this.gameObject);
            //}
           
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }


}
