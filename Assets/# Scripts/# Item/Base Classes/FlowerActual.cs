using UnityEngine;

public class FlowerActual : Item
{
    [SerializeField] private string FlowerName;
    [SerializeField] private string FlowerDesc;
    [SerializeField] private string TypeOfFlower;

    public override ItemData ItemPickedUp() 
    {
        FlowerData flowerData = new FlowerData(FlowerName, TypeOfFlower, FlowerDesc, GetComponent<SpriteRenderer>().sprite);
        return flowerData;
    }
}
