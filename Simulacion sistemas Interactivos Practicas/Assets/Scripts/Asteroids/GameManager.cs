using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance { get; private set; }
    public bool inGame;
    [SerializeField] Text text_points, text_lvl;
    [SerializeField] AsteroidsSpawn spawner;
    public int lvl, points;
    [SerializeField] GameObject boton_start;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {/*
            text_points.gameObject.SetActive(true);
            text_lvl.gameObject.SetActive(true);
            text_points.text = ("Current point: " + points);
            text_lvl.text = ("Current Lvl: " + lvl);*/
            if (points > 30 * lvl)
            {
                lvl++;
                spawner.ChangeLvl();
            }
        }
    }
    public void AddPoint()
    {
        points++;
    }
    public void StartGame()
    {
        lvl = 1;
        spawner.ChangeLvl();
        inGame = true;
        boton_start.SetActive(false);
    }
}
