using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] private int playerGems;

    // Private Fields
    private int _maxGems = 999;

    // Events
    public delegate void PlayerCurrencyModified(int gems);
    public static event PlayerCurrencyModified OnPlayerCurrencyModified;

    // Public Properties
    public int PlayerGems { get { return playerGems; } }

    public void BuyItem(int costOfItem)
    {
        playerGems -= costOfItem;
        OnPlayerCurrencyModified?.Invoke(PlayerGems);
    }

    public void SellItem(int resaleOfItem)
    {
        playerGems += resaleOfItem;
        OnPlayerCurrencyModified?.Invoke(PlayerGems);
    }

    private void Start()
    {
        OnPlayerCurrencyModified?.Invoke(PlayerGems);
    }

}
