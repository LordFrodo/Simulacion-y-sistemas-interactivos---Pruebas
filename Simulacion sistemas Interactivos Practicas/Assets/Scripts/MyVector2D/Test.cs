using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public MyVector2D vector_a, vector_b, vector_difference,vector_interpolation, origin;
    [SerializeField] private float constant;
    [Range(0f,1f)]
    [SerializeField] private float  parameter;

    // Start is called before the first frame update
    void Awake()
    {
        parameter = Random.Range(0f, 1f);
        vector_difference = new MyVector2D(0f, 0f);
        vector_a = new MyVector2D(10f, 20f);
        vector_b = new MyVector2D(5f, 10f);
        origin = new MyVector2D (0f,0f);
        vector_interpolation = new MyVector2D(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            vector_difference = vector_a.Normalize(vector_a);
            vector_difference.Magnitude_Calculate(vector_difference);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            vector_difference = vector_difference.Sum(vector_a, vector_b);
            vector_difference.Magnitude_Calculate(vector_difference);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            vector_difference = vector_difference.Substract(vector_a, vector_b);
            //vector3.Magnitude_Calculate(vector3);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            vector_difference = vector_difference.Multiply_Constant(constant, vector_a);
            vector_difference.Magnitude_Calculate(vector_difference);
        }
        //Draw vector a
        vector_a.DrawMyVector(vector_a, Color.green);

        //Draw vector diference and move it
        vector_difference.DrawMyVector(vector_difference, Color.red);
        vector_difference.DrawMyVector(vector_difference, vector_b, Color.cyan);

        //Draw vector b
        vector_difference.DrawMyVector(vector_b, Color.blue);

        //vector3.DrawMyVector(vector3,origin, Color.red);
        Debug.Log("La magnitud es de: "+vector_difference.Magnitude);
        Debug.Log(vector_difference);

        //Update the values of vector diference
        vector_difference = vector_difference.Substract(vector_a, vector_b);

        //Calculate and draw Vector interpolation
        vector_interpolation = vector_interpolation.Lerp(vector_a, vector_b, parameter);
        vector_interpolation.DrawMyVector(vector_interpolation, Color.yellow);
        

    }
}
