using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructible))]
public class StoneHitPointsText : MonoBehaviour
{
    [SerializeField] private Text hitPointText;

    private Destructible destructible;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();
        destructible.ChangeHitPoints.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoint);
    }

    private void OnChangeHitPoint()
    {
        int hitPoints = destructible.GetHitPoint();

        if (hitPoints >= 1000)
        {
            hitPointText.text = hitPoints / 1000 +"K";
        }
        else
        {
            hitPointText.text = hitPoints.ToString();
        }
    }
}
