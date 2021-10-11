using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtVelocity : MonoBehaviour
{
    [Header("Velocity properties")]
    [SerializeField] float follow_speed;
    [Header ("Change Acceleration Method")]
    [SerializeField] bool accelerate;
    Vector3 velocity;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (accelerate) FollowAceleration();
        else Follow();
    }
    public void Follow()
    {
        var mouseposition = MyCustomLookAt.GetWorldMousePosition();
        mouseposition.Draw(Color.white);
        transform.rotation = MyCustomLookAt.LookAt(mouseposition, transform.position);
        Vector3 current_positiion = transform.position;
        Vector3 direction = (mouseposition - current_positiion).normalized;
        velocity = direction * follow_speed;
        Vector3 final_position = new Vector3(velocity.x, velocity.y, 0);
        transform.position += final_position * Time.deltaTime;
    }
    public void FollowAceleration()
    {
        var mouseposition = MyCustomLookAt.GetWorldMousePosition();
        mouseposition.Draw(Color.white);
        Vector3 current_positiion = transform.position;
        transform.rotation = MyCustomLookAt.LookAt(current_positiion + velocity);
        Vector3 acceleration = mouseposition - current_positiion;
        velocity = velocity + acceleration * Time.deltaTime;
        Vector3 final_position = new Vector3(velocity.x, velocity.y, 0);
        transform.position += final_position * Time.deltaTime;
    }
}
