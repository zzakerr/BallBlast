using UnityEngine;

public class Turret: MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startBulletPos;
    [SerializeField] private float offset;

    private float fireRate;   
    private int amountBullet;
    private int damage;

    public float FireRate => fireRate;
    public int AmountBullet => amountBullet;
    public int Damage => damage;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnBullet()
    {
        float startPosX = startBulletPos.position.x - offset * (amountBullet - 1) * 0.5f;

        for(int i = 0; i < amountBullet; i++)
        {
            
            Bullet bullet = Instantiate(bulletPrefab, new Vector3(startPosX + i *offset,startBulletPos.position.y,startBulletPos.position.z), Quaternion.identity);
            bullet.SetDamage(damage);
        }      
    }

    public void Fire()
    {
        if (timer > 1/fireRate)
        {
            SpawnBullet();
            timer = 0;
        } 
    }

    public void SetFireRate(float amount)
    {
        fireRate = amount;
    }

    public void SetDamage(int amount)
    {
       damage = amount;
    }

    public void SetAmountBullet(int amount)
    {
        amountBullet = amount;
    }

}
