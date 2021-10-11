using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilacion : MonoBehaviour
{
    float time;
    [SerializeField] float magnitude;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector3(Mathf.Sin(time)*magnitude,0,0);
    }
}
