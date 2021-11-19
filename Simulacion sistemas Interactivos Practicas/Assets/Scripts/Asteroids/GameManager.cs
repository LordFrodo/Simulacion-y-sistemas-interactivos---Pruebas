using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance { get; private set; }
    public bool inGame,dead;
    [SerializeField] Text text_points, text_lvl;
    [SerializeField] AsteroidsSpawn spawner;
    public int lvl, points;
    [SerializeField] GameObject boton_start, reset_buton;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            text_points.gameObject.SetActive(true);
            text_lvl.gameObject.SetActive(true);
            text_points.text = ("Current point: " + points);
            text_lvl.text = ("Current Lvl: " + lvl);
            if (points > 30 * lvl)
            {
                lvl++;
                spawner.ChangeLvl();
            }
        }
        if(dead)
        {
            text_points.gameObject.SetActive(false);
            text_lvl.gameObject.SetActive(false);
            reset_buton.SetActive(true);
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
