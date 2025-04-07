using UnityEngine;

public class SpikedWheels : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float stickForce = 10f; // Сила прилипания
    [SerializeField] private float checkDistance = 5f; // Дистанция проверки
    [SerializeField] private LayerMask groundLayer; // Слой поверхности
    public Rigidbody2D[] Wheels;


    void Start()
    {
             
    }   
    
    void FixedUpdate()
    {
        
        if (Physics2D.CircleCast(transform.position, checkDistance, Vector2.zero, groundLayer))
        {
            foreach (var wheel in Wheels)
            {
                // Прижимаем колесо к поверхности
                wheel.gravityScale = 0.2f;
                Vector2 dashDirection = transform.up;
                wheel.linearVelocity = dashDirection * stickForce;
                //rb.AddForce(dashDirection * stickForce, ForceMode2D.Force);
                Debug.Log("Я у земли");
            }
        }
        else 
        {
            foreach (var wheel in Wheels)
            {
                wheel.gravityScale = 1;
            }
        }
    }
}