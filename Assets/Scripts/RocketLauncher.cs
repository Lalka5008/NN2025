using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject RocketFake;
    public GameObject RocketFakeWig;
    public GameObject Rocket;
    public Rigidbody2D RBRocket;
    public Vector2 LaunchForce;
    private bool lauched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lauched && Rocket != null) Launch();
    }
    private void Launch()
    {
        RocketFake.SetActive(false);
        RocketFakeWig.SetActive(false);
        Rocket.transform.SetParent(null);
        Rocket.SetActive(true);
        RBRocket.bodyType = RigidbodyType2D.Dynamic;
        RBRocket.linearVelocity = LaunchForce;
    }
    public void InitiateLauch()
    {
        bool activated = false;
        if (activated == false)
        {
            lauched = true;
        }
        else 
        {
            Debug.Log("AlreadyLaunched");
        }
    }
}
