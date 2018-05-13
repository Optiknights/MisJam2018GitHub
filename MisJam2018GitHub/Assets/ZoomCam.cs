using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public float zoomSpeed = 5f;

    Camera cam;
    float camFOV;

    void Start()
    {
        cam = GetComponent<Camera>();
        camFOV = cam.fieldOfView;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camFOV += zoomSpeed * Time.deltaTime;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camFOV -= zoomSpeed * Time.deltaTime;
        }

        cam.fieldOfView = Mathf.Clamp(camFOV, 20, 80);
    }
}