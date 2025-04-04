using UnityEngine;

public class SimpleWheelStick3D : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float stickForce = 10f; // Сила прилипания
    [SerializeField] private float checkDistance = 0.5f; // Дистанция проверки
    [SerializeField] private LayerMask groundLayer; // Слой поверхности
    [SerializeField] private float maxSlopeAngle = 45f; // Максимальный угол наклона

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Бросаем луч вниз (в 3D)
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, checkDistance, groundLayer))
        {
            // Проверяем допустимый угол наклона поверхности
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            if (slopeAngle <= maxSlopeAngle)
            {
                // Прижимаем колесо к поверхности
                rb.AddForce(Vector3.down * stickForce, ForceMode.Force);

                // Компенсация подпрыгивания
                if (rb.linearVelocity.y > 0)
                {
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.9f, rb.linearVelocity.z);
                }
            }
        }
    }

    // Визуализация луча в редакторе
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * checkDistance);
    }
}