using UnityEngine;

public class MarketInteraction : MonoBehaviour
{
    [SerializeField] GameObject UIBuy;
    [SerializeField] GameObject UISell;

    /// <summary>
    /// Toggles the Market... For now just enables BUY MODE, in the future will prompt a Yarnspinner Dialogue
    /// </summary>
    public void EnterMarket()
    {
        UIBuy.SetActive(true);
    }

    /// <summary>
    /// Will exit the Market, for now will only toggle the Buy Menu.
    /// </summary>
    public void ExitMarket() 
    {
        UIBuy.SetActive(false);
    }
}
