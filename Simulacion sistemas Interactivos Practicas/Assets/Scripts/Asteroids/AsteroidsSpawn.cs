using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{
    [SerializeField] float cantidad;
    public int lvl_spawn;
    int cantidad_spawneada;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (lvl_spawn == GameManager.instance.lvl&&GameManager.instance.inGame)
        {  
            if(cantidad_spawneada < cantidad)
            {
                PoolAsteroids.instance.Get().transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
                PoolAsteroids.instance.Get().transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), 0));
                cantidad_spawneada++;            
            }    
        }
       
    }
    public void ChangeLvl()
    {
        lvl_spawn = GameManager.instance.lvl;
        cantidad*= lvl_spawn;
    }
}
