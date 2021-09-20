using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FluidInteractions : MonoBehaviour
{
    
    public static Action On_fluid_event;
   
    public void OntriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Fluid")) On_fluid_event?.Invoke();
        Debug.Log("HOLA");
    }
    public void OntriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Fluid")) On_fluid_event?.Invoke();
    }
    
}
