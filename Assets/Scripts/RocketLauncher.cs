using System.Collections;
using System.Net.Sockets;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject RocketFake;
    public GameObject RocketFakeWig;
    public GameObject Rocket;
    public Rigidbody2D RBRocket;
    public Rigidbody2D createdRb;
    public Vector2 LaunchForce;
    private bool lauched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (lauched && Rocket != null) Launch();
    }
    private void Launch()
    {
 
        //createdRb.linearVelocity = LaunchForce;

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3);
        lauched = false;
        RocketFake.SetActive(true); 
        RocketFakeWig.SetActive(true);
    }

    public void InitiateLauch()
    {
        //RocketFake.SetActive(false);
        //RocketFakeWig.SetActive(false);
        Instantiate(Rocket, RocketFake.transform);
        //createdRb = created.GetComponent<Rigidbody2D>();
        //StartCoroutine(Cooldown());
        //bool activated = false;
        //if (activated == false)
        //{
        //    lauched = true;
        //}
        //else 
        //{
        //    Debug.Log("AlreadyLaunched");
        //}
    }
}
