using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Camera cam;

    Vector3 latestTouchPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //set custom cursor! Cursor.SetCursor(...)
        latestTouchPos = Vector3.zero;
    }

    //Mobile Version
    public Vector3 getWorldMousePos() {
        if(Input.touches.Length > 0) {
            // at least 1 finger on the screen
            Touch t = Input.touches[0];
            latestTouchPos = t.position;
        }
        Vector3 p = cam.ScreenToWorldPoint(latestTouchPos);
        p.z = 0;
        return p;
    }

    /*
    // Desktop Version
    public Vector3 getWorldMousePos() {
        Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0;
        return p;
    }
    */

}
