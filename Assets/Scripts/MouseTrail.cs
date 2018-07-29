using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrail : MonoBehaviour

{

    public Camera mainCamera;
    Vector3 point = new Vector3();


    void Update()
    {
        point = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 550));
        transform.position = new Vector3(point.x, point.y, 550);
    }
}
