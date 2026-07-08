using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseableFlowerPotsPerFlower", menuName = "Scriptable Objects/UseableFlowerPotsPerFlower")]
public class UseableFlowerPots : ScriptableObject
{
    [SerializeField] private Dictionary<string, int> potVariants = new Dictionary<string, int>();

    public void Initialize()
    {

    }

    //public bool FlowerInFlowerPot(GameObject potPassed, out GameObject potRecieved )
    //{
    //    foreach(var pot in potVariants)
    //    {
    //        if(pot.Key == potPassed)
    //        {
    //            potRecieved = pot.Value;
    //            return true;
    //        }
    //    }
    //    potRecieved = null;
    //    return false;
    //}
}
