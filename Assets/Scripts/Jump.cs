using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void InitiateJump(float force)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
    }

}
