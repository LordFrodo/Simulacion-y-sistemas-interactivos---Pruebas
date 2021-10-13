using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilacion : MonoBehaviour
{
    [Header("Component X")]
    [Range(1f, 5)]
    [SerializeField] float magnitude_x;
    [Range(1f, 20)]
    [SerializeField] float speed_x;
    [Header("Component Y")]
    [Range(1f,5)]
    [SerializeField] float magnitude_y;
    [Range(1f, 20)]
    [SerializeField] float speed_y;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time*speed_x)*magnitude_x, Mathf.Sin(Time.time * speed_y) * magnitude_y, 0);
    }
}
