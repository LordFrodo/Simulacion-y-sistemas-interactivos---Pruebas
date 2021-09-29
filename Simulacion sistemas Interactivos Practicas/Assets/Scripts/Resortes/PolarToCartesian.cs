using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarToCartesian : MonoBehaviour
{
    [Header("Coordenadas")]
    public Vector2 polar_coord, cartesian_coord;
    [SerializeField] AnimationCurve curve;
    
    public float radius, duration, raduis_magnitude, angle_magnitud;
    float t, time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        t = time / duration;
        radius = curve.Evaluate(t)*raduis_magnitude;
        polar_coord.y = curve.Evaluate(t)*angle_magnitud;
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
