using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;
    [SerializeField] private Transform rightWheel;
    [SerializeField] private Transform leftWheel;
    [SerializeField] private float wheelRadius;

    [HideInInspector] public UnityEvent CollisionStone;

    private Vector3 movementTarget;
    private float deltaMovement;

    private void Start()
    {
        movementTarget = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();
        if (stone != null)
        {
            CollisionStone.Invoke();
        }

    }

    private void Update()
    {
        Move();
        WheelRotator();
    }

    private void Move()
    {
        float lastPositionX = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
        deltaMovement = transform.position.x - lastPositionX;
    }

    public void SetMovementTarget(Vector3 target)
    {        
        movementTarget = ClampMovementTarget(target);
    }

    public void WheelRotator()
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);
        rightWheel.Rotate(Vector3.forward,-angle);
        leftWheel.Rotate(Vector3.forward,-angle);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = LevelBoundàry.Instance.LeftBoarder + vehicleWidth * 0.5f;
        float rightBorder = LevelBoundàry.Instance.RightBoarder - vehicleWidth * 0.5f;

        Vector3 movTarget = target;
        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;

        if(movTarget.x < leftBorder) movTarget.x = leftBorder;
        if(movTarget.x > rightBorder) movTarget.x = rightBorder;
        return movTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
        Gizmos.DrawLine(rightWheel.position - new Vector3(0, wheelRadius, 0), rightWheel.position + new Vector3(0, wheelRadius, 0));
    }
#endif
}
