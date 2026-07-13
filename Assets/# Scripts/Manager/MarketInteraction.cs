using UnityEngine;
using Yarn.Unity;

public class MarketInteraction : MonoBehaviour
{
    [Header("UI Options")]
    [SerializeField] GameObject UIBuy;
    [SerializeField] GameObject UISell;

    // Private Vars
    private bool isSellActivate = false;


    // Public Properties
    public bool IsSellActivate { get { return isSellActivate; } } 

    /// <summary>
    /// Toggles the Market... For now just enables BUY MODE, in the future will prompt a Yarnspinner Dialogue
    /// </summary>
    public void InteractWithMarket()
    {
        DialogueManager.Instance.OpenShopDialogue();
    }

    [YarnCommand("open_market_sell")]
    public void OpenMarketSell()
    {
        UISell.SetActive(true);
    }

    [YarnCommand("open_market_buy")]
    public void OpenMarketBuy()
    {
        Debug.Log("OPENING BUY SECTION");
        UIBuy.SetActive(true);
    }

    public void EnterSellMarketDEBUG()
    {
        Debug.Log("RAN");
        UISell.SetActive(true);
    }

    /// <summary>
    /// Will exit the Market, for now will only toggle the Buy Menu.
    /// </summary>
    public void ExitMarket() 
    {
        if (UIBuy.activeSelf)
        {
            isSellActivate = false;
            UIBuy.SetActive(false);
        }
        else if (UISell.activeSelf)
        {
            UISell.SetActive(false);
        }

        DialogueManager.Instance.CloseShopDialogue();
    }
}
