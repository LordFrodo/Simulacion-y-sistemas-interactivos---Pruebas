using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePos : MonoBehaviour
{
    Vector3 screen_pos;

    // Update is called once per frame
    void Update()
    {

        screen_pos.x = Input.mousePosition.x;
        screen_pos.y = Input.mousePosition.y;
        screen_pos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(screen_pos);
    }
}
