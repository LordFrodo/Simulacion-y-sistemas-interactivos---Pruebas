using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mouseposition = GetWorldMousePosition();
        mouseposition.Draw(Color.white);
        transform.rotation = LookAt(mouseposition, transform.position);
    }
    public  static Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }
    private static Quaternion RotateZ(float radians)
    {
        return Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
    public static Quaternion LookAt(Vector3 position, Vector3 origin)
    {
        float angle = Mathf.Atan2(position.y-origin.y, position.x-origin.x);
        return RotateZ(angle);      
    }
    public static Quaternion LookAt(Vector3 position)
    {
        float angle = Mathf.Atan2(position.y, position.x);
        return RotateZ(angle);
    }
}
