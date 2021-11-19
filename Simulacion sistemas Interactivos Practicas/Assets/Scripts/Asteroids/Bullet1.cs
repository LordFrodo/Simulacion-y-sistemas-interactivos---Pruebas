using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet1 : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] float force;
    [SerializeField] float bullet_duration;

    private void OnEnable()
    {
        StartCoroutine("RetunrToPool");
    }
    public IEnumerator RetunrToPool()
    {
        yield return new WaitForSeconds(bullet_duration);
        PoolMuniciones.instance.Return(gameObject);
    }
    private void Update()
    {
        //transform.localPosition += transform.up/10;
        transform.localPosition += Shoots.direction.normalized/10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            PoolMuniciones.instance.Return(gameObject);
        }
    }
}
