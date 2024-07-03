using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int lifeTime;
    private int damage;
    private Collider2D lastCollider;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lastCollider == collision) return;
        lastCollider = collision;
        Destructible destructible = collision.transform.root.GetComponent<Destructible>();
        Cart cart = collision.transform.root.GetComponent<Cart>();     
        if (destructible == true)
        {
            destructible.ApplyDamage(damage);
                       
        }
        if (cart == true)
        {
            return;
        }
        
        Destroy(gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        lastCollider = null;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
