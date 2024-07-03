using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private GameManager gameManager;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed = false;


    private void Awake()
    {
        gameManager.EndComlited.AddListener(OnSpawnTogle);
        spawner.Completed.AddListener(OnSpawnTogle);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }

    private void OnDestroy()
    {
        gameManager.EndComlited.RemoveListener(OnSpawnTogle);
        spawner.Completed.RemoveListener(OnSpawnTogle);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }

    private void OnSpawnTogle()
    {
        checkPassed = !checkPassed;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            if(checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0 && FindObjectsOfType<Coin>().Length == 0)
                {
                    Passed.Invoke();
                }
            }
            timer = 0f;
        }
    }
}
