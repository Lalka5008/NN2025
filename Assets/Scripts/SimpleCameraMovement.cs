using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;  // �������� ���� ������
    public float smoothSpeed = 5f; // ������� ��������� (3-5 ���������)
    public Vector3 offset = new Vector3(0, 0, -10); // Z=-10 ��� 2D

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,desiredPos,smoothSpeed * Time.deltaTime);
    }
}