using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarToCartesian : MonoBehaviour
{
    [Header("Coordenadas")]
    public Vector2 polar_coord, cartesian_coord;
    [Header("Curva de animacion")]
    [SerializeField] AnimationCurve curve;
    [Header("Angular Speed")]
    public float angular_speed;
    public float angular_acceleration;
    [Header("Radial Speed")]
    public float radial_speed;
    public float radial_acceleration;
    [Header("Limites pantalla")]
    public float screen_radius;
    [Header("Variables Movimiento con curva")]
    public float radius;
    public float duration;
    public float raduis_magnitude;
    public float angle_magnitud;
    float t, time;

    // Update is called once per frame
    void FixedUpdate()
    {
        /* Crecimiento de la espiral debido a la curva hecha en el inspector
        time += Time.deltaTime;
        t = time / duration;
        radius = curve.Evaluate(t)*raduis_magnitude;
        polar_coord.y = curve.Evaluate(t)*angle_magnitud;*/
        if (Mathf.Abs(radius) > screen_radius)
        {
            radial_acceleration = -radial_acceleration;
        }
        //Crecimiento de la espiral por medio de aceleracion y velocidad
        angular_speed += angular_acceleration * Time.deltaTime;
        radial_speed += radial_acceleration * Time.deltaTime;
        radius = radial_speed;
        polar_coord.y = angular_speed;
        polar_coord.x = radius;
        cartesian_coord = PolarToCartesianCoord(polar_coord);
        transform.position = cartesian_coord;
        cartesian_coord.Draw(Color.yellow);
    }
    public Vector2 PolarToCartesianCoord(Vector2 polar_coord)
    {
        Vector2 temp = new Vector2(0,0);
        temp.x = polar_coord.x * Mathf.Cos(polar_coord.y);
        temp.y = polar_coord.x * Mathf.Sin(polar_coord.y);
        return temp;
    }
}
