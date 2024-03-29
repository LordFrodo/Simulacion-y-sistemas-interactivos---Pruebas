using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public MyVector2D position, velocity, aceleration,black_hole_position;
    [SerializeField] float max_Y_displacement, max_X_displacement, min_Y_displacement, min_X_displacement, vel_max;
    [Range(0, 1)]
    [SerializeField] float bouncingness_factor;
    [SerializeField] GameObject black_hole;
    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        black_hole_position.X = black_hole.transform.position.x;
        black_hole_position.Y = black_hole.transform.position.y;
        UpdatePosition();
        position.DrawMyVector(position, Color.red);
        position.DrawMyVector(velocity, position, Color.blue);
        position.DrawMyVector(aceleration, position, Color.yellow);
        if (position.Y > max_Y_displacement && position.X > max_X_displacement)
        {
            transform.position = new Vector3(5, 5, 0);
        }
        transform.position = new Vector3(position.X, position.Y, 0);
        aceleration.X = aceleration.Substract(black_hole_position, position).X;
        aceleration.Y = aceleration.Substract(black_hole_position, position).Y;

    }
    public void UpdatePosition()
    {
        //if (position.Y >= max_Y_displacement || position.Y <= min_Y_displacement)
        //{
        //    velocity.Y = -velocity.Y * bouncingness_factor;
        //    //aceleration.Y = -aceleration.Y;
        //}
        //if (position.X >= max_X_displacement || position.X <= min_X_displacement)
        //{
        //    velocity.X = -velocity.X * bouncingness_factor;
        //    //aceleration.X = -aceleration.X;
        //}

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
        //if (position.Y > max_Y_displacement)
        //{
        //    position.Y = max_Y_displacement;
        //}
        //if (position.X > max_X_displacement)
        //{
        //    position.X = max_X_displacement;
        //}
        //if (position.X < min_X_displacement)
        //{
        //    position.X = min_X_displacement;
        //}
        //if (position.Y < min_Y_displacement)
        //{
        //    position.Y = min_Y_displacement;
        //}
        //transform.position += temp;
    }
}
