using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    [SerializeField] Transform spawnpoint_bullets;
    public static Vector3 direction;
    float time;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameManager.instance.inGame) Shoot();
        time += Time.deltaTime;
        direction = spawnpoint_bullets.transform.position - gameObject.transform.position;
        direction.Normalize();
    }
    public void Shoot()
    {
        if (time < 0.5f) return;
        time = 0;
        PoolMuniciones.instance.Get().transform.position = spawnpoint_bullets.transform.position;
        PoolMuniciones.instance.Get().transform.rotation = spawnpoint_bullets.transform.rotation;
    }
}
