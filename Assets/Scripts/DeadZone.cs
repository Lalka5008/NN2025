using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Rigidbody2D Car;
    public Rigidbody2D[] Wheels;
    private Vector3 car_Position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car_Position = Car.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var wheel in Wheels) 
            {
                wheel.bodyType = RigidbodyType2D.Static;
                wheel.transform.position = car_Position;
            }
            Car.bodyType = RigidbodyType2D.Static;
            Car.position = new Vector3(-15f, -5, 0);
            Car.rotation = 0f;
            foreach (var wheel in Wheels)
            {
                wheel.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
