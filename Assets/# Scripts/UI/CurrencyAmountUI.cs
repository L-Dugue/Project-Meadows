using TMPro;
using UnityEngine;

public class CurrencyAmountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyAmountText;

    private void Awake()
    {
        PlayerCurrency.OnPlayerCurrencyModified += UpdateCurrencyUI;
    }

    public void UpdateCurrencyUI(int currentCurrencyAmount)
   {
        Debug.Log("RAN");
        currencyAmountText.text = currentCurrencyAmount.ToString();
   }

}
