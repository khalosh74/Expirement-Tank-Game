using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    //float leftConstraint = Screen.width;
    //float rightConstraint = Screen.width;
    //float buffer = 1.0f;
    //Camera cam;
    //float distanceX;

    //void Start()
    //{
    //    cam = Camera.main;
    //    distanceX = Mathf.Abs(cam.transform.position.x + transform.position.x);
    //    leftConstraint = cam.ScreenToWorldPoint(new Vector2(distanceX, 0.0f)).x;
    //    rightConstraint = cam.ScreenToWorldPoint(new Vector2(Screen.width, distanceX)).x;
    //}

    //void FixedUpdate()
    //{
    ////    if (transform.position.x < leftConstraint - buffer)
    ////    {
    ////        if (GetComponent<Movement>().moveParent)
    ////        {
    ////            transform.parent.position = new Vector2(rightConstraint - 0.10f, transform.position.y);
    ////        }
    ////        else
    ////        {
    ////            transform.position = new Vector2(rightConstraint - 0.10f, transform.position.y);
    ////        }
    ////    }
    ////    if (transform.position.x > rightConstraint)
    ////    {
    ////        if (GetComponent<Movement>().moveParent)
    ////        {
    ////            transform.parent.position = new Vector2(leftConstraint - 0.10f, transform.position.y);
    ////        }
    ////        else
    ////        {
    ////            transform.position = new Vector2(leftConstraint - 0.10f, transform.position.y);
    ////        }
    ////    }
    //}
}
