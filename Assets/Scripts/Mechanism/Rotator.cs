using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{


    bool ismoving;

    [SerializeField] float rotatespeed;
    [SerializeField] bool clockwise;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ismoving = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ismoving = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(delay());
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        if (clockwise == true && ismoving == true)
        {
            transform.Rotate(0, 0, -rotatespeed * Time.deltaTime);
        }
        else if(clockwise == false && ismoving == true)
        {
            transform.Rotate(0, 0, rotatespeed * Time.deltaTime);
        }
    }
    private void OnMouseDown()
    {
        ismoving = true;
    }

    private void OnMouseUp()
    {
        ismoving = false;
    }

   IEnumerator delay()
    {
        yield return new WaitForSeconds(2.0f);
        ismoving = false;
    }

}
