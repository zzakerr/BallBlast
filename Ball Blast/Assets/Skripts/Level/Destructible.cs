using UnityEngine;
using UnityEngine.Events;


public class Destructible : MonoBehaviour
{
    public int MaxHitPoints;
    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChangeHitPoints;

    private int hitPoints;

    private bool isDay = false;

    private void Start()
    {    
        hitPoints = MaxHitPoints;
        ChangeHitPoints.Invoke();
    }

    public void AddHitPoint(int health)
    {
        if (hitPoints + health >= MaxHitPoints)
        {
            hitPoints = MaxHitPoints;
            ChangeHitPoints.Invoke();
            return;
        }
        hitPoints += health;
        ChangeHitPoints.Invoke();

    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        ChangeHitPoints.Invoke();
        
        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (isDay) return;        
        hitPoints = 0;
        isDay = true;
        ChangeHitPoints.Invoke();
        Die.Invoke();    
    }

    public int GetHitPoint()
    {
        return hitPoints;
    }
}
