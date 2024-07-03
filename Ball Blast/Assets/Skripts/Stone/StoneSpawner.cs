using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StoneSpawner : MonoBehaviour
{
    public static StoneSpawner Instance;
    [SerializeField] private Turret turret;
    [SerializeField] private UIProgressBar progressBar;

    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
  
    [Header("Balance")] 
    [SerializeField] private float maxHitPointsRate;
    [SerializeField] [Range(0f, 1f)] private float minHitPointsPercentage;

    [HideInInspector] private int amount;
    [HideInInspector] private float spawnRate;

    public UnityEvent Completed;

    private int amountSpawned;
    private int stoneMinHitPoint;
    private int stoneMaxHitPoint;
    private float posStoneZ;
    private float timer;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        enabled = false;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {            
            timer = 0;
            Spawn();
            amountSpawned++; 
        }

        if (amountSpawned >= amount)
        {
            enabled = false;
            Completed.Invoke();
            amountSpawned = 0;
        }
    }

    private void Spawn()
    {
        posStoneZ -= 0.1f;
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);     
        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.SetRandomColor32();
        stone.transform.Translate(0,0,posStoneZ); 
        stone.MaxHitPoints = Random.Range(stoneMinHitPoint + 1, stoneMaxHitPoint);
        if (stone.size == Stone.Size.Huge) progressBar.AddStones(15);
        if (stone.size == Stone.Size.Big) progressBar.AddStones(7);
        if (stone.size == Stone.Size.Normal) progressBar.AddStones(3);
        if (stone.size == Stone.Size.Small) progressBar.AddStones(1);

    }

    public void EnableSpawnStone(int amountStone , float spawnRate)
    {
        int damagePerSecond = (int)(turret.Damage * turret.AmountBullet * turret.FireRate);
        stoneMaxHitPoint = (int)(damagePerSecond * maxHitPointsRate);
        stoneMinHitPoint = (int)(stoneMaxHitPoint * minHitPointsPercentage);
        timer = spawnRate;
        this.spawnRate = spawnRate;
        amount = amountStone;
        enabled = true;
    }

}
