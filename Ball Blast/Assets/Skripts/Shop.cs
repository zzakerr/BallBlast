using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Upgrades upgrades;
    [SerializeField] private TMP_Text boxUpgrade;
    [SerializeField] private TMP_Text boxLvl;
    [SerializeField] private Text boxPrice;
    private string damageUpgradeText = "Damage";
    private string fireRateUpgradeText = "Fire Rate";
    private string amountBulletUpgradeText = "Amount Bullet";
    private int price;
    private int upgradeNumber = 1;

    public void UpdateShop()
    {       
        if (upgradeNumber == 1) BulletBox();
        if (upgradeNumber == 2) FireRateBox();
        if (upgradeNumber == 3) DamageBox();
        boxPrice.text = price.ToString();
    }

    public void SelectorRight()
    {
        upgradeNumber++;
        if (upgradeNumber == 4) upgradeNumber = 1;
        UpdateShop();
    }

    public void SelectorLeft()
    {
        upgradeNumber--;
        if (upgradeNumber == 0) upgradeNumber = 3;
        UpdateShop();
    }

    private void BulletBox()
    {
        price = Mathf.CeilToInt(upgrades.AmountBullet) * 5;
        boxUpgrade.text = amountBulletUpgradeText;
        boxLvl.text = upgrades.AmountBullet.ToString();
    }

    private void FireRateBox()
    {
        price = Mathf.CeilToInt(upgrades.FireRate) * 5;
        boxUpgrade.text = fireRateUpgradeText;
        boxLvl.text = upgrades.FireRate.ToString();
    }

    private void DamageBox()
    {
        price = Mathf.CeilToInt(upgrades.Damage) * 5;
        boxUpgrade.text = damageUpgradeText;
        boxLvl.text = upgrades.Damage.ToString();
    }

    public void BuyUpgrade()
    {
        if (CoinCollectors.Instance.Coin >= price) 
        {
            if (upgradeNumber == 1) upgrades.UpgradeAmountBullet();
            if (upgradeNumber == 2) upgrades.UpgradeFireRate();
            if (upgradeNumber == 3) upgrades.UpgradeDamage();

            CoinCollectors.Instance.RemoveCoin(price);
            UpdateShop();
            Debug.Log("Upgrade! " + boxUpgrade);
            return;
        }
        Debug.Log("Not Enought money");
    } 
}
