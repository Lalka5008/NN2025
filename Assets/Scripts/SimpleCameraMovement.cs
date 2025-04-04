using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;  // Перетащи сюда игрока
    public float smoothSpeed = 5f; // Настрой плавность (3-5 нормально)
    public Vector3 offset = new Vector3(0, 0, -10); // Z=-10 для 2D

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,desiredPos,smoothSpeed * Time.deltaTime);
    }
}