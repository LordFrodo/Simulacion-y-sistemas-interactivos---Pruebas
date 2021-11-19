using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMuniciones : MonoBehaviour
{
    public static PoolMuniciones instance { get; private set; }
    [SerializeField] GameObject prefab;
    [SerializeField] int initial_amount;
    List<GameObject> list_bullets = new List<GameObject>();
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
            list_bullets.Add(temp);
        }
    }
    public GameObject Get()
    {
        GameObject ret;
        if (list_bullets.Count > 0)
        {
            ret = list_bullets[list_bullets.Count - 1];
            list_bullets.RemoveAt(list_bullets.Count - 1);
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
        list_bullets.Add(bullet);
    }
}
