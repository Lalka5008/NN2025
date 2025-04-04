using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void InitiateDash(float force)
    {
        Vector2 dashDirection = transform.right;
        rb.linearVelocity = dashDirection * force;
    }

}
