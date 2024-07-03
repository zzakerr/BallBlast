using UnityEngine;
using UnityEngine.Events;

public class CoinCollectors : MonoBehaviour
{
    public static CoinCollectors Instance;
    [SerializeField] private UnityEvent coinState;
    private int coin;

    public int Coin => coin;

    private void Awake()
    {
        Load();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);       
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        coinState.Invoke();
        Save();
    }

    public bool RemoveCoin(int amount)
    {
        if (coin - amount < 0 ) return false;
        coin -= amount;
        coinState.Invoke();
        Save();
        return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }

    private void Load()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
    }
}
