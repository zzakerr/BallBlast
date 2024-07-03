using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }

    [SerializeField] public Size size;
    [SerializeField] private float spawnUpForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [HideInInspector] public UnityEvent StoneDie;
    private float posStoneZ;
    private StoneMovement movement;

    private void Awake()
    {
        movement = GetComponent<StoneMovement>();
        Die.AddListener(onStoneDestroyed);
        SetSize(size);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(onStoneDestroyed);
    }

    private void onStoneDestroyed()
    {
        if (size != Size.Small)
        {          
            SpawnStones();  
        }
        StoneDie.Invoke();
        Destroy(gameObject);
    }

    private void SpawnStones()
    {
        for (int i = 0;i<2;i++)
        {
            posStoneZ -= 0.1f;
            Stone stone = Instantiate(this,transform.position,Quaternion.identity);
            stone.SetSize(size - 1);
            stone.MaxHitPoints = Mathf.Clamp(MaxHitPoints / 2, 1, MaxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);
            stone.transform.Translate(0, 0, posStoneZ);
        }   
    }

    public void SetSize(Size size)
    {
        if (size < 0) return;

        transform.localScale = GetVectorSize(size);
        this.size = size;
    }

    public void SetRandomColor32()
    {
        spriteRenderer.color = Colors32Manager.Instance.GetRandomColor32();
    }

    private Vector3 GetVectorSize(Size size)
    {
        if (size == Size.Small)  return new Vector3 (0.4f, 0.4f, 0.4f); 
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        return Vector3.one;
    }
}
