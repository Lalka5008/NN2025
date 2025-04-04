using UnityEngine;

public class SimpleWheelStick3D : MonoBehaviour
{
    [Header("���������")]
    [SerializeField] private float stickForce = 10f; // ���� ����������
    [SerializeField] private float checkDistance = 0.5f; // ��������� ��������
    [SerializeField] private LayerMask groundLayer; // ���� �����������
    [SerializeField] private float maxSlopeAngle = 45f; // ������������ ���� �������

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ������� ��� ���� (� 3D)
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, checkDistance, groundLayer))
        {
            // ��������� ���������� ���� ������� �����������
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            if (slopeAngle <= maxSlopeAngle)
            {
                // ��������� ������ � �����������
                rb.AddForce(Vector3.down * stickForce, ForceMode.Force);

                // ����������� �������������
                if (rb.linearVelocity.y > 0)
                {
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.9f, rb.linearVelocity.z);
                }
            }
        }
    }

    // ������������ ���� � ���������
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * checkDistance);
    }
}