using UnityEngine;
using UnityEngine.UI;

public class CoinHUD : MonoBehaviour
{
    [SerializeField] private Text amountCoinText;

    private void Awake()
    {
        UpdateHudCoin();
    }

    public void UpdateHudCoin()
    {
        int coin = CoinCollectors.Instance.Coin;
        if (coin < 10) {amountCoinText.text = "0000" + coin; return; }
        if (coin < 100) { amountCoinText.text = "000" + coin; return;}
        if (coin < 1000) { amountCoinText.text = "00" + coin; return;}
        if (coin < 10000) { amountCoinText.text = "0" + coin; return;}
        if (coin < 100000) { amountCoinText.text = "" + coin; return;}
    }
}
