using UnityEngine;

public class SpawnOnMouseClick : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ �������, ������� ����� ��������
    public LayerMask triggerLayer;    // ����, �� ������� ��������� ��������

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��������� ������� ���
        {
            // �������� ������� ���� � ������� �����������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ���������, ����� �� ��� � �������
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, triggerLayer))
            {
                // ������� ������ �� ������� ���� � Z = 0
                Vector3 spawnPosition = hit.point;
                spawnPosition.z = 0f; // ��������� Z

                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}