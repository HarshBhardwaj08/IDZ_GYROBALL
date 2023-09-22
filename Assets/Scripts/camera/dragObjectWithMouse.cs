using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObjectWithMouse : MonoBehaviour
{
    Vector2 diffrence = Vector2.zero;
    [SerializeField] GameObject cam;
   
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnMouseEnter()
    {
     
        diffrence = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
     
     

    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)- diffrence;
     
    }
  

   


}
