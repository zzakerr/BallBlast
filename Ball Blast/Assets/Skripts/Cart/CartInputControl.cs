using UnityEngine;

[RequireComponent(typeof(Cart))]
[RequireComponent(typeof(Turret))]
public class CartInputControl : MonoBehaviour
{
    private Cart cart;
    private Turret turret;

    private void Start()
    {
        cart = GetComponent<Cart>();
        turret = GetComponent<Turret>();
    }

    private void Update()
    {
        cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            turret.Fire();
        }
    }
}
