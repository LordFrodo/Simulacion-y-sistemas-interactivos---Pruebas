using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{
    [SerializeField] float cantidad;
    public int lvl_spawn;
    int cantidad_spawneada;

    public void ChangeLvl()
    {
        lvl_spawn = GameManager.instance.lvl;
        cantidad *= lvl_spawn;

        for (int i = 0; i < cantidad; ++i)
        {
            var asteroid = PoolAsteroids.instance.Get();
            asteroid.transform.position = new Vector3(Random.Range(-5, 5), 5, 0);
            asteroid.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f)));
        }
    }
}
