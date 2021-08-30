using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public MyVector2D position, velocity, aceleration;
    [SerializeField] float health, max_Y_displacement, max_X_displacement, min_Y_displacement, min_X_displacement, vel_max;
    bool acelerate = true;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        position.DrawMyVector(position, Color.red);
        position.DrawMyVector(velocity, position, Color.blue);
        position.DrawMyVector(aceleration, position, Color.yellow);
        if (position.Y > max_Y_displacement && position.X > max_X_displacement)
        {
            transform.position = new Vector3(5, 5, 0);
        }
        transform.position = new Vector3(position.X, position.Y, 0);


    }
    public void UpdatePosition()
    {
        if (position.Y >= max_Y_displacement || position.Y <= min_Y_displacement)
        {
            velocity.Y = -velocity.Y;
            //aceleration.Y = -aceleration.Y;
        }
        if (position.X >= max_X_displacement || position.X <= min_X_displacement)
        {
            velocity.X = -velocity.X;
            //aceleration.X = -aceleration.X;
        }
        //Normalizo la velocidad
        velocity = velocity.Normalize(velocity);
        velocity = velocity.Multiply_Constant(vel_max, velocity);
        //Acelera el vector velocidad
        velocity.Y += aceleration.Y * Time.deltaTime;
        velocity.X += aceleration.X * Time.deltaTime;



        //Agrego velocidad
        position.Y += velocity.Y * Time.deltaTime;
        position.X += velocity.X * Time.deltaTime;
        if (position.Y > max_Y_displacement)
        {
            position.Y = max_Y_displacement;
        }
        if (position.X > max_X_displacement)
        {
            position.X = max_X_displacement;
        }
        if (position.X < min_X_displacement)
        {
            position.X = min_X_displacement;
        }
        if (position.Y < min_Y_displacement)
        {
            position.Y = min_Y_displacement;
        }
        //transform.position += temp;
    }
}
