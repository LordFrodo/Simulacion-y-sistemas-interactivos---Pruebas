using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    List<GameObject> circles = new List<GameObject>();
    [Header("Cantidad de circulos")]
    [SerializeField] int howManyCircles;
    [Header("Valores de la ola")]
    [Range(1, 5)]
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    [SerializeField] float factor;
    [Header("Objeto")]
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < howManyCircles; i++)
        {
            var circle = Instantiate(prefab, transform);
            circles.Add(circle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < howManyCircles; i++)
        {
            var circle = circles[i];
            float x = 0.6f * i;
            float y = amplitude*Mathf.Sin(i*factor+Time.time*speed);
            circle.transform.localPosition = new Vector3(x, y);
        }
    }
}
