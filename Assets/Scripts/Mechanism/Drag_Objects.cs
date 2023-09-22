using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Objects : MonoBehaviour
{
    Vector2 diffrence = Vector2.zero;
    [SerializeField] GameObject camera_main;

    private void Start()
    {
        camera_main = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnMouseDown()
    {
       
        diffrence = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)(transform.position);
    }
    private void OnMouseDrag()
    {
     
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - diffrence;
    }
  
}
