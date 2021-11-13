using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet1 : MonoBehaviour
{
    Rigidbody2D rg;
    Vector3 direction;
    float force;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
