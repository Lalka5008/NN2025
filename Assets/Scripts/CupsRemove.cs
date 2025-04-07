using UnityEngine;
using System.Collections.Generic;

public class CupsRemove : MonoBehaviour
{
    public List<GameObject> cups = new List<GameObject>();
    private Collider2D colliderThis;

    void Start()
    {
        colliderThis = GetComponent<Collider2D>();
        // Получаем всех детей (включая вложенные)
        GetAllChildren(transform, cups);
    }

    // Рекурсивный метод для получения всех детей
    void GetAllChildren(Transform parent, List<GameObject> childrenList)
    {
        foreach (Transform child in parent)
        {
            childrenList.Add(child.gameObject);
            GetAllChildren(child, childrenList);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Удар был");
            
            colliderThis.GetComponent<Collider2D>().enabled = false;
            
            foreach (GameObject c in cups)
            {
                if (c != null)
                {
                    
                    var collider = c.GetComponent<Rigidbody>();
                    if (collider != null)
                        collider.isKinematic = false;
                        collider.linearVelocity = new Vector3(Random.Range(-4f, 4f), Random.Range(1f, 4f), Random.Range(-4f, 4f));
                }
            }
        }
    }
}