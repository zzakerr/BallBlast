using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{

    [SerializeField] private Text curentLevel;
    [SerializeField] private Text nextLevel;
    [SerializeField] private Image barFill;
    [SerializeField] private GameManager gameManager;

    private float maxAmount;
    private float fillAmountStep;

    private void Awake()
    {
        barFill.fillAmount = 1;
        UpdateLevel();        
    }

    public void BarHit()
    {
        barFill.fillAmount -= fillAmountStep;
    }

    public void Reset()
    {
        barFill.fillAmount = 1;
        maxAmount = 0;
        UpdateLevel();
    }

    public void AddStones(int amount)
    {    
        maxAmount += amount;
        fillAmountStep = 1 / maxAmount;
    }

    public void UpdateLevel()
    {
        curentLevel.text = gameManager.Level.ToString();
        nextLevel.text = (gameManager.Level + 1).ToString();
    }
}
