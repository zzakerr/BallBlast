using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private Turret turret;
    private float fireRate;
    private int amountBullet;
    private int damage;
    private float fierRateMath;

    public float FireRate => fireRate;
    public int AmountBullet => amountBullet;
    public int Damage => damage;

    private void Awake()
    {
        Load();
        turret.SetAmountBullet(amountBullet);
        turret.SetDamage(damage);
        turret.SetFireRate(fireRate);
    }

    public void UpgradeDamage()
    {
        damage++;
        turret.SetDamage(damage);
        Save();
    }

    public void UpgradeFireRate()
    {
        fireRate++;
        turret.SetFireRate(fireRate);
        Save();
    }

    public void UpgradeAmountBullet()
    {
        amountBullet++;
        turret.SetAmountBullet(amountBullet);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Bullet",amountBullet);
        PlayerPrefs.SetInt("Damage",damage);
        PlayerPrefs.SetFloat("FireRate",fireRate);
    }

    private void Load()
    {
       amountBullet = PlayerPrefs.GetInt("Bullet",1);
       damage = PlayerPrefs.GetInt("Damage", 1);
       fireRate = PlayerPrefs.GetFloat("FireRate", 1);
    }
}
