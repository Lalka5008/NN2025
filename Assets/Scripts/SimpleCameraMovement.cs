using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;  // �����
    public float smoothSpeed = 5f; // ���������
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        Vector3 wherewewant = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, wherewewant, smoothSpeed * Time.deltaTime);
    }
}