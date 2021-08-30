using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MyVector2D
{
    [SerializeField] private float y;
    protected float magnitude, direction;
    [SerializeField] private float x;

    public float Magnitude { get => magnitude; set => magnitude = value; }
    public float Direction { get => direction; set => direction = value; }
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public float Magnitude_Calculate(MyVector2D vector)
    {
        magnitude = (float)Math.Sqrt(Math.Pow((double)vector.x, (double)2) + Math.Pow((double)vector.y, (double)2));
        return magnitude;
    }

    public MyVector2D Sum(MyVector2D vector1, MyVector2D vector2)
    {
        MyVector2D temp = new MyVector2D(0, 0);
        temp.x = (vector1.x + vector2.x);
        temp.y = (vector1.y + vector2.y);
        return temp;
    }
    public MyVector2D Substract(MyVector2D vector1, MyVector2D vector2)
    {
        MyVector2D temp = new MyVector2D(0, 0);
        temp.x = vector1.x - vector2.x;
        temp.y = vector1.y - vector2.y;
        return temp;
    }
    public MyVector2D Multiply_Constant(float constant, MyVector2D vector)
    {
        MyVector2D temp = new MyVector2D(0, 0);
        temp.x = vector.x * constant;
        temp.y = vector.y * constant;
        return temp;
    }
    public MyVector2D Normalize(MyVector2D vector)
    {
        if (vector.Magnitude == 0) vector.magnitude = Magnitude_Calculate(vector);
        MyVector2D temp = new MyVector2D(0, 0);
        temp.x = vector.x / vector.Magnitude;
        temp.y = vector.y / vector.Magnitude;
        return temp;
    }
    public void DrawMyVector(MyVector2D vector, Color color)
    {
        Vector3 temp = new Vector3(vector.x, vector.y, 0f);
        Debug.DrawLine(Vector3.zero, temp, color);
    }
    public void DrawMyVector(MyVector2D vector,MyVector2D origin, Color color)
    {
        Vector3 origin_temp = new Vector3(origin.x, origin.y, 0f);
        Vector3 temp = new Vector3(vector.x, vector.y, 0f);
        Debug.DrawLine(origin_temp, temp+origin_temp, color);
    }
    public override string ToString()
    {
        return ("Vector = (" + x + " , " + y + ")");
    }
    public MyVector2D Lerp(MyVector2D vector_a,MyVector2D vector_b,float constant)
    {
        MyVector2D difference = new MyVector2D(0f, 0f);
        MyVector2D temp = new MyVector2D(0f, 0f);
        MyVector2D finish = new MyVector2D(0f, 0f);
        difference = difference.Substract(vector_b, vector_a);
        temp = temp.Multiply_Constant(constant, difference);
        finish = finish.Sum(vector_a, temp);
        return finish;

    }
}
