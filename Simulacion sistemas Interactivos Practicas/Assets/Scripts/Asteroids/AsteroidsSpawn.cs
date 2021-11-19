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
                if (Random.value > 0.5f)
                {
                    PoolAsteroids.instance.Get().transform.position = new Vector3(-7,7, 0);
                    PoolAsteroids.instance.Get().transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f)));
                }
                else
                {
                    PoolAsteroids.instance.Get().transform.position = new Vector3(7,-7, 0);
                    PoolAsteroids.instance.Get().transform.rotation = Quaternion.Euler(new Vector3(0,0, Random.Range(0f, 360f)));
                }
               
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
