using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] public UIProgressBar progressBar;
    [HideInInspector] public UnityEvent EndComlited;
    

    private int level;
    public int Level => level;

    private void Awake()
    {
        Load();
        cart.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        spawner.EnableSpawnStone(level,10/level);
        progressBar.gameObject.SetActive(true);
        progressBar.Reset();
        cart.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        level++;
        Save();
    }

    public void EndGame()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        for (int i = 0; i < coins.Length; i++)
        {
            Destroy(coins[i].gameObject);
        }

        Stone[] gameObject = FindObjectsOfType<Stone>();     
        for (int i = 0; i < gameObject.Length; i++)
        {
            Destroy(gameObject[i].gameObject);
        }

        progressBar.gameObject.SetActive(false);    
        cart.gameObject.SetActive(false);
        EndComlited.Invoke();
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Level", Level);  
    }

    private void Load()
    {
        level = PlayerPrefs.GetInt("Level", 1);       
    }
}
