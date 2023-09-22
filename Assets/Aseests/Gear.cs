using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] bool clockwise;
    [SerializeField] float speed;
    float store_speed;
    void Start()
    {
        store_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {   
        if(clockwise == true)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
       
    }
    private void OnMouseDown()
    {
        speed = 0;
    }
    private void OnMouseUp()
    {
        speed = store_speed;
    }
}
