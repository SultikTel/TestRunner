using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera cameraMain;
    // Update is called once per frame
    private void Start()
    {
        cameraMain = Camera.main;
    }
    void Update()
    {
        transform.LookAt(cameraMain.transform);
    }
}
