using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public MyVector2D position, velocity, aceleration;
    [SerializeField] protected float  max_Y_displacement, max_X_displacement, min_Y_displacement, min_X_displacement, vel_max;
    [Range(0, 1)]
    [SerializeField] protected float bouncingness_factor;

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
    public virtual void UpdatePosition()
    {
        if (position.Y >= max_Y_displacement || position.Y <= min_Y_displacement)
        {
            velocity.Y = -velocity.Y*bouncingness_factor;
            //aceleration.Y = -aceleration.Y;
        }
        if (position.X >= max_X_displacement || position.X <= min_X_displacement)
        {
            velocity.X = -velocity.X*bouncingness_factor;
            //aceleration.X = -aceleration.X;
        }
        
        //Acelera el vector velocidad
        velocity.Y += aceleration.Y * Time.deltaTime;
        velocity.X += aceleration.X * Time.deltaTime;

        //Ajuste Vel max
        velocity.Magnitude_Calculate(velocity);
        if (velocity.Magnitude > vel_max)
        {
            velocity = velocity.Normalize(velocity);
            velocity = velocity.Multiply_Constant(vel_max, velocity);
        }

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
