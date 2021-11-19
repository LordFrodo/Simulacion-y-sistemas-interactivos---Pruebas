using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAsteroids : MonoBehaviour
{
    public static PoolAsteroids instance { get; private set; }
    [SerializeField] GameObject prefab;
    [SerializeField] int initial_amount;
    List<GameObject> list_aseteroids = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < initial_amount; i++)
        {
            GameObject temp = Instantiate(prefab);
            temp.SetActive(false);
            list_aseteroids.Add(temp);
        }
    }
    public GameObject Get()
    {
        GameObject ret;
        if (list_aseteroids.Count > 0)
        {
            ret = list_aseteroids[list_aseteroids.Count - 1];
            list_aseteroids.RemoveAt(list_aseteroids.Count - 1);
        }
        else
        {
            ret = Instantiate(prefab);
        }
        ret.SetActive(true);
        return ret;
    }
    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
        list_aseteroids.Add(bullet);
    }
}
