using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    GameObject ob;
    public float rotate = 15;
    float x;
    float y;
    float z;
    public float speed = 10;

    void Start(){
        ob = GameObject.FindWithTag("Test");
    }
    public void OnLeft(){
        ob = GameObject.FindWithTag("Test");
        x = ob.transform.eulerAngles.x;
        y = ob.transform.eulerAngles.y;
        z = ob.transform.eulerAngles.z;
        ob.transform.rotation =  Quaternion.Euler(x, y + rotate, z);
    }
    public void OnRight(){
        ob = GameObject.FindWithTag("Test");
        x = ob.transform.eulerAngles.x;
        y = ob.transform.eulerAngles.y;
        z = ob.transform.eulerAngles.z;
        ob.transform.rotation =  Quaternion.Euler(x, y - rotate, z);
    }

    
}
