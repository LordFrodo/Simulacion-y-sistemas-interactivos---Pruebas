using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public MyVector2D vector, vector2, vector3,vector4,vector5, origin;
    [SerializeField] private float constant, parameter;

    // Start is called before the first frame update
    void Awake()
    {
        parameter = Random.Range(0f, 1f);
        vector3 = new MyVector2D(0f, 0f);
        vector = new MyVector2D(10f, 20f);
        vector2 = new MyVector2D(5f, 10f);
        origin = new MyVector2D (0f,0f);
        vector4 = new MyVector2D(0f, 0f);
        vector5 = new MyVector2D(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            vector3 = vector.Normalize(vector);
            vector3.Magnitude_Calculate(vector3);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            vector3 = vector3.Sum(vector, vector2);
            vector3.Magnitude_Calculate(vector3);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            vector3 = vector3.Substract(vector, vector2);
            //vector3.Magnitude_Calculate(vector3);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            vector3 = vector3.Multiply_Constant(constant, vector);
            vector3.Magnitude_Calculate(vector3);
        }
        vector.DrawMyVector(vector, Color.green);
        vector3.DrawMyVector(vector3, Color.red);
        vector3.DrawMyVector(vector2, Color.blue);
        vector3.DrawMyVector(vector3, vector2, Color.cyan);
        //vector3.DrawMyVector(vector3,origin, Color.red);
        Debug.Log("La magnitud es de: "+vector3.Magnitude);
        Debug.Log(vector3);
        vector3 = vector3.Substract(vector, vector2);
        vector4 = vector4.Multiply_Constant(parameter, vector3);
        vector5 = vector5.Substract(vector, vector4);
        vector5.DrawMyVector(vector5, Color.yellow);

    }
}
