using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By Jasper
//Purpose of this script is to create a rotator for the main camera
public class CameraRotator : MonoBehaviour
{
    public float speed; //adjustable variable to control speed of rotation

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); 
    }
}
