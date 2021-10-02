using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerForce : Walker
{
    [SerializeField] protected MyVector2D force, friction, accumulated_force, gravity, weight;
    [SerializeField] protected float mass, coefficient_friction, normal_force;

    void Start()
    {
        weight.X = gravity.X * mass;
        weight.Y = gravity.Y * mass;
    }
    public void ApplyForce(MyVector2D force)
    {
        accumulated_force.X += force.X / mass;
        accumulated_force.Y += force.Y / mass;
    }
    public override void UpdatePosition()
    {
        aceleration.X = 0;
        aceleration.Y = 0;
        if (position.Y >= max_Y_displacement || position.Y <= min_Y_displacement)
        {
            velocity.Y = -velocity.Y * bouncingness_factor;
        }
        if (position.X >= max_X_displacement || position.X <= min_X_displacement)
        {
            velocity.X = -velocity.X * bouncingness_factor;
        }
         friction.X = -coefficient_friction * normal_force * friction.Normalize(velocity).X;
         friction.Y = -coefficient_friction * normal_force * friction.Normalize(velocity).Y;
        ApplyForce(friction);
        ApplyForce(force);
        
        accumulated_force = accumulated_force.Sum(accumulated_force, weight);
        aceleration = accumulated_force;
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
    }
    private void Update()
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
    
}
