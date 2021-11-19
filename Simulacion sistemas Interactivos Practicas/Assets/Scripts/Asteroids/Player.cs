using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            explosion.Play();
            gameObject.GetComponent<SpriteRenderer>().material.color = new Vector4(0, 0, 0, 0);
            StartCoroutine("Dead");
        }
    }

    public IEnumerator Dead()
    {
        explosion.Play();
        yield return new WaitForSeconds(1.5f);
        explosion.Stop();
        gameObject.SetActive(false);
    }
}
