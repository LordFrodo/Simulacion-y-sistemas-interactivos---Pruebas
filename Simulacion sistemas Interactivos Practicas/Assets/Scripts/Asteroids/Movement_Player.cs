using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement_Player : MonoBehaviour
{
    [Header ("Variables")]
    [SerializeField] float force;
    [Range(0,1)]
    int state = 1;
    Vector3 direction;
    [SerializeField] GameObject turbo;
    float time;

    Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.inGame) AddForce(state);

        time += Time.deltaTime;
        if (time > 0.5)
        {
            turbo.SetActive(false);
            state = 1;
        }

        if (transform.position.x <= -5.5 || transform.position.x >= 5.5) transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        if (transform.position.y <= -5.5 || transform.position.y >= 5.5) transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
    }
    public void AddForce(int x)
    {
        Debug.Log(state);
        switch (x)
        {
            case 0:
                break;
            case 1:
                    turbo.SetActive(true);
                    state = 0;
                    direction = MyCustomLookAt.GetWorldMousePosition();
                    direction = direction - transform.position;
                    direction.Normalize();
                    rg.AddForce(direction * force);
                    time = 0;
            break;
        }
    }
    
}
