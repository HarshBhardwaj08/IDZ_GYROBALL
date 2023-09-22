using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUpwards : MonoBehaviour
{
    public float upwardAngle;
    public float upwardforce;
    void Start()
    {
        
    }

   
    void Update()
    {
        Debug.DrawLine(transform.position, (transform.position + (Quaternion.Euler(0, 0, upwardAngle) * Vector3.up * 5)), Color.green, 1.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 Force = Quaternion.Euler(0, 0, upwardAngle) * Vector2.up * upwardforce;
          
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
           
        }
    }
}
