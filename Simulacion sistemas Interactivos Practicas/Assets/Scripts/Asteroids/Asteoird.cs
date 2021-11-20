using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteoird : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float asteroid_life;
    [SerializeField] ParticleSystem ps;
    float speed = 2; // m/s
    float tiempo;

    private void Start()
    {
        //ps.GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        StartCoroutine("RetunrToPool");
        //ps.Play();
    }

    public IEnumerator RetunrToPool()
    {
        yield return new WaitForSeconds(asteroid_life);
        PoolMuniciones.instance.Return(gameObject);
    }

    private void Update()
    {
        //tiempo += Time.deltaTime;
        //if (tiempo > 0.8) ps.Pause();

        // Move asteroid
        transform.localPosition += transform.up * speed * Time.deltaTime;

        // Check edges
        if (transform.position.x <= -5.5 || transform.position.x >= 5.5)
        {
            if (transform.position.x <= -5.5)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-120, 120)));
            }
            else
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-60, 60)));
            }

            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }
        if (transform.position.y <= -5.5 || transform.position.y >= 5.5)
        {
            if (transform.position.y <= -5.5)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(220, 330)));
            }
            else
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(30, 150)));
            }

            transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
        }

        if (GameManager.instance.inGame == false) PoolAsteroids.instance.Return(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //ps.Play();
            PoolAsteroids.instance.Return(gameObject);
            GameManager.instance.AddPoint();
        }
    }
}
