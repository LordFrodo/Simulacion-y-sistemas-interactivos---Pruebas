using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Easing
{
    Linear,
    easeInCubic,
    easeInQuad
}
public class MyTween : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] GameObject[] target;
    [Range(0, 1)]
    [SerializeField] float t;
    float accumulated_time, final_T;
    bool isPlaying;
    int current_target;
    [SerializeField] Easing easing;
    

    Vector3 start_pos, end_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        end_pos = target[current_target].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ResetTween();
        if (!isPlaying) return;
        t = accumulated_time / duration;
        switch (easing)
        {
            case Easing.Linear:
                final_T = (Linear(t));
                break;
            case Easing.easeInCubic:
                final_T = (EaseInCubic(t));
                break;
            case Easing.easeInQuad:
                final_T = (EaseInQuad(t));
                break;
        }

        transform.position = Vector3.Lerp(start_pos, end_pos, final_T); //Este si le importa el limite donde se esta almacenando
                                                                  //transform.position = Vector3.LerpUnclamped(start_pos, end_pos, t); Este no le importa el limite de la variable donde se este almacenando
        if (t >= 1)
        {
            start_pos = end_pos;
            if (current_target < target.Length) current_target++;
            else current_target = target.Length - 1;
            end_pos = target[current_target].transform.position;
            isPlaying = false;
            return;
            //ResetTween();

        }




        accumulated_time += Time.deltaTime;
    }
    public void ResetTween()
    {
        t = 0;
        accumulated_time = 0;
        isPlaying = true;
        end_pos = target[current_target].transform.position;
    }
    private float Linear(float t)
    {
        return t;
    }
    private float EaseInCubic(float t)
    {
        return t * t * t;
    }
    private float EaseInQuad(float t)
    {
        return t * t;
    }
}
