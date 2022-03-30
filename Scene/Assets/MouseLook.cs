using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes{
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;
    public float verticalRot = 0;
    public float minVer = -45.0f;
    public float maxVer = 45.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX){
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }else if (axes == RotationAxes.MouseY){
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
            verticalRot = Mathf.Clamp(verticalRot, minVer, maxVer);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else{
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
            verticalRot = Mathf.Clamp(verticalRot, minVer, maxVer);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}