using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelJoint2D[] wheels; // Массив колёс

    public float speed = 1000f;
    public float maxTorque = 1000f;
    public int Time;
    public float MultiPlayer;


    private void Start()
    {
        StartCoroutine(SlowStart(Time));
    }
    void Update()
    {


        // Для каждого колеса
        foreach (WheelJoint2D wheel in wheels)
        {

                JointMotor2D motor = wheel.motor;
                motor.motorSpeed = speed; // Направление движения
                motor.maxMotorTorque = maxTorque;
                wheel.motor = motor;
       
        }
    }
    IEnumerator SlowStart(int seconds)
    {
        while (seconds > 0) 
        {
            yield return new WaitForSeconds(MultiPlayer);
            speed += 100;
            seconds--;

        }
        yield return null;
    }
}