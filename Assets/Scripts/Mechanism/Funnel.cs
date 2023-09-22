using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
   [SerializeField] GameObject movelocation;
    //  Rigidbody2D rg2d;
    Vector3 original_pos;
    void Start()
    {
        original_pos = transform.position;
       // rg2d = GetComponent<Rigidbody2D>();
      //  rg2d.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(moveTunnel());
         //   rg2d.bodyType = RigidbodyType2D.Dynamic;

        }
    }

    IEnumerator moveTunnel()
    {
        yield return new WaitForSeconds(2.0f); 
        transform.position = movelocation.transform.position;
        yield return new WaitForSeconds(3.0f);
        transform.position = original_pos;
    }
    
}
