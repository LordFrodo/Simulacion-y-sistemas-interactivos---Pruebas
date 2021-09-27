using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterFriction : WalkerForce
{
    [SerializeField] MyVector2D water_friction;
    [SerializeField] float coefficient_fluids, fluid_density, frontal_area;
    bool on_fluid;
    
    public void Start()
    {
        FluidInteractions.On_fluid_event += Fluid_interaction;
        weight.X = gravity.X * mass;
        weight.Y = gravity.Y * mass;
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
        water_friction.X = -0.5f * fluid_density * velocity.X * velocity.X * frontal_area * coefficient_fluids * water_friction.Normalize(velocity).X;
        water_friction.Y = 0.5f * fluid_density * velocity.Y * velocity.Y * frontal_area * coefficient_fluids * water_friction.Normalize(velocity).Y;
        Debug.Log(water_friction.Y);
        if(on_fluid)ApplyForce(water_friction);
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
    public void Fluid_interaction(bool entering)
    {
        on_fluid = entering;
    }
}
