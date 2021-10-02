using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FluidInteractions : MonoBehaviour
{
    //Func <> es un action que devuelve algo

    public delegate void CustomAction(bool x); //crear un action que tiene nuevos parametros y puede guardar nuevos datos
    public static event CustomAction On_fluid_event; //el keyword event se usa para indicar que el delegado "On_fluid_event" solo se invocara en la clase que lo define.

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player")) On_fluid_event?.Invoke(true);
    }

    public void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player")) On_fluid_event?.Invoke(false);
    }    
}
