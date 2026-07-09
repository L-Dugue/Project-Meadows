using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseableFlowerPotsPerFlower", menuName = "Scriptable Objects/UseableFlowerPotsPerFlower")]
public class UseableFlowerPots : ScriptableObject
{
    [SerializeField] private GameObject[] flowersInPots = new GameObject[2];
    [SerializeField] private GameObject[] pots = new GameObject[2];

    public bool FlowerInFlowerPot(GameObject potPassed, out GameObject potRecieved)
    {
        Dictionary<GameObject, GameObject> potVariants = new Dictionary<GameObject, GameObject>();
        for (int i = 0; i < pots.Length; i++)
        {
            potVariants.Add(pots[i], flowersInPots[i]);
        }

        foreach (var pot in potVariants)
        {
            Debug.Log(potPassed);
            if (pot.Key == potPassed)
            {
                potRecieved = pot.Value;
                return true;
            }
        }
        potRecieved = null;
        return false;
    }
}
