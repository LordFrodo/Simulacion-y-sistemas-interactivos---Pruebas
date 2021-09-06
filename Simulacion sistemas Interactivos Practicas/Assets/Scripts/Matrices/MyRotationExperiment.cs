using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotationExperiment : MonoBehaviour
{
    [Range (0f,360f)]
    [SerializeField] float rotation;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        #region BlanckBox
        transform.position = new Vector4(4f, 0f, 0f);
        Quaternion myQuaternion = Quaternion.Euler(0f, 0f, rotation); 
        #endregion
        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(myQuaternion);
        transform.position = rotationMatrix * transform.position;
    }
}
