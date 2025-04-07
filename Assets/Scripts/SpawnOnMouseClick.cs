using UnityEngine;

public class SpawnOnMouseClick : MonoBehaviour
{
    public GameObject objectToSpawn; // Префаб объекта, который нужно спавнить
    public LayerMask triggerLayer;    // Слой, на котором находятся триггеры

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие ЛКМ
        {
            // Получаем позицию мыши в мировых координатах
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Проверяем, попал ли луч в триггер
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, triggerLayer))
            {
                // Спавним объект на позиции мыши с Z = 0
                Vector3 spawnPosition = hit.point;
                spawnPosition.z = 0f; // Фиксируем Z

                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}