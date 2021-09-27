using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    const float gravity = 0.667408f;
    [SerializeField] float factor, radius;
    [SerializeField] Rigidbody[] targetRigidbody;
    [SerializeField] Transform[] target;
    Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radius);
        Transform[] target = new Transform[hitcolliders.Length];
        Rigidbody[] targetRigidbody = new Rigidbody[hitcolliders.Length];
        rg = GetComponent<Rigidbody>();
        for (int i = 0; i < hitcolliders.Length; i++)
        {
            target[i] = hitcolliders[i].transform;
            targetRigidbody[i] = target[i].GetComponent<Rigidbody>();
        }
        this.target = target;
        this.targetRigidbody = targetRigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 difference = transform.position - target[i].position;
            float r = difference.magnitude;
            float magnitude = ((rg.mass * targetRigidbody[i].mass) * gravity) / (r * r);
            Vector3 direction = difference.normalized;

            Vector3 force = direction * magnitude;

            if (r > 1) targetRigidbody[i].AddForce(force);
            else targetRigidbody[i].velocity = Vector3.zero;
        }
    }

}
