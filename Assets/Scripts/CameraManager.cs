using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void Update()
    {
        if(Input.GetButtonDown("StartGame"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
        
}
