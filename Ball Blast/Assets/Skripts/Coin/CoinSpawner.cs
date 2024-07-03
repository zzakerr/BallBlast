using UnityEngine;

[RequireComponent(typeof(Stone))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin coinPrefab;
    [SerializeField][Range(0f, 99f)] private int spawnChance;
    private int maxBorderChance = 10;
    private Stone DieEvent;

    protected virtual void Awake()
    {
        DieEvent = GetComponent<Stone>();
        DieEvent.StoneDie.AddListener(SpawnCoin);
    }

    private void OnDestroy()
    {
        DieEvent.StoneDie.RemoveListener(SpawnCoin);
    }

    public void SpawnCoin()
    {
        int min = spawnChance / 10;
        int i = Random.Range(min, maxBorderChance);
        if (i == min) Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
