using UnityEngine;

public class Coin: MonoBehaviour
{
    [SerializeField] private int coinPrice; 
    public int CoinPrice => coinPrice;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LevelEdge>() != null)
        {
            LevelEdge levelEdge = collision.GetComponent<LevelEdge>();
            if (collision.GetComponent<LevelEdge>().Type == EdgeType.Bottom)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
        if (collision.transform.root.GetComponent<Cart>() != null)
        {
            CoinCollectors.Instance.AddCoin(CoinPrice);
            Destroy(gameObject);
        }
    }
}
