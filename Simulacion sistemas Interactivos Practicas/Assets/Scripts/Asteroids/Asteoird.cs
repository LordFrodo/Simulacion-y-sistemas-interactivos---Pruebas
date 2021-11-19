using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteoird : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float asteroid_life;
    [SerializeField] ParticleSystem ps;
    float tiempo;

    private void Start()
    {
        ps.GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        StartCoroutine("RetunrToPool");
        ps.Play();
    }
    public IEnumerator RetunrToPool()
    {
        yield return new WaitForSeconds(asteroid_life);
        PoolMuniciones.instance.Return(gameObject);
    }
    private void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > 0.8) ps.Pause();
        transform.localPosition += transform.up/40;
        if (transform.position.x <= -7||transform.position.x>=7) transform.position = new Vector3(-transform.position.x, transform.position.y,0);
        if (transform.position.y <= -7 || transform.position.y >= 7) transform.position = new Vector3(transform.position.x,-transform.position.y, 0);
        if(GameManager.instance.inGame==false) PoolMuniciones.instance.Return(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            new WaitForSeconds(1);
            ps.Play();
            PoolMuniciones.instance.Return(gameObject);
            GameManager.instance.AddPoint();
        }
    }
}
