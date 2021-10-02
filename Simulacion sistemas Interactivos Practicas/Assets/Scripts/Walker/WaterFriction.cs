using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterFriction : WalkerForce
{
    [SerializeField] MyVector2D water_friction;
    [SerializeField] float coefficient_fluids, fluid_density, frontal_area;
    bool on_fluid;
    
    private void Start()
    {
        FluidInteractions.On_fluid_event += Fluid_interaction;
        weight.X = gravity.X * mass;
        weight.Y = gravity.Y * mass;
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void OnDestroy()
    {
        // Deregister/unsubscribe from static event
        FluidInteractions.On_fluid_event -= Fluid_interaction;
    }

    private void Update()
    {
        UpdatePosition();
        //position.DrawMyVector(position, Color.red);
        //position.DrawMyVector(velocity, position, Color.blue);
        //position.DrawMyVector(aceleration, position, Color.yellow);
        //if (position.Y > max_Y_displacement && position.X > max_X_displacement)
        //{
        //    transform.position = new Vector3(5, 5, 0);
        //}
        transform.position = new Vector3(position.X, position.Y, 0);
    }

    public override void UpdatePosition()
    {
        // Reset the accumulated force
        accumulated_force.X = 0;
        accumulated_force.Y = 0;

        // Do some bouncing
        if (position.Y >= max_Y_displacement || position.Y <= min_Y_displacement)
        {
            velocity.Y = -velocity.Y * bouncingness_factor;
        }
        if (position.X >= max_X_displacement || position.X <= min_X_displacement)
        {
            velocity.X = -velocity.X * bouncingness_factor;
        }

        // Apply fluid resistance force
        if (on_fluid)
        {
            MyVector2D dir = velocity.Normalize(velocity);
            float speed = velocity.Magnitude_Calculate(velocity);
            float scalarPart = -0.5f * fluid_density * speed * speed * frontal_area * coefficient_fluids;
            water_friction = dir.Multiply_Constant(scalarPart, dir);
            ApplyForce(water_friction);
        }

        // Add weight to total forces
        ApplyForce(weight);

        // Set the acceleration, accumulated force is F=m/a -> a=F/m
        aceleration = accumulated_force;

        // Acelera el vector velocidad
        velocity.Y += aceleration.Y * Time.deltaTime;
        velocity.X += aceleration.X * Time.deltaTime;

        // Ajuste Vel max
        velocity.Magnitude_Calculate(velocity);
        if (velocity.Magnitude > vel_max)
        {
            velocity = velocity.Normalize(velocity);
            velocity = velocity.Multiply_Constant(vel_max, velocity);
        }

        // Agrego velocidad
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

    public void Fluid_interaction(bool entering)
    {
        Debug.Log("fluid");
        on_fluid = entering;
    }
}
