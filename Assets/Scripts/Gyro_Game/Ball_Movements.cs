using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movements : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Camera mainCamera;
    [SerializeField] GameObject pos_up,pos_left,pos_right;
    [SerializeField] LayerMask ground_layer;
    [SerializeField] Transform ground_check_point;
    [SerializeField] bool isgrounded;
    [SerializeField] float jumpforce;
    [SerializeField] float gravity;
    [SerializeField] float diry;
    public float sensitivity = 10.0f; // Adjust sensitivity as needed.

   

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // Enable the gyroscope.
    }

    private void Update()
    {
        float dirx = Input.acceleration.x * sensitivity * Time.deltaTime;
        float yMove = Input.acceleration.y*4*Time.deltaTime;
        float diry = -gravity * Time.deltaTime; // Gravity should be applied constantly.

      //  Debug.Log("dirx = " + dirx + " diry = " + diry);

        if (dirx > 0.02)
        {
            rb2D.velocity += new Vector2(dirx, yMove);
        }
        else if (dirx < -0.02)
        {
            rb2D.velocity += new Vector2(dirx, yMove);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y); // Maintain vertical velocity, only update horizontal.
        }

        isgrounded = Physics2D.Raycast(ground_check_point.position, Vector2.down, 0.50f, ground_layer);
        Debug.DrawLine(ground_check_point.position, ground_check_point.position + Vector3.down * 0.50f, Color.green, 0.50f);

        if (Input.GetMouseButton(0) && isgrounded)
        {
            rb2D.velocity = Vector2.up * jumpforce;
        }
    }



    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boxy")
        {

            transform.position = pos_up.transform.position;
        }
        
        else if (collision.gameObject.tag == "Boxy_left")
        {

            transform.position = pos_right.transform.position;
        }
        else if (collision.gameObject.tag == "Boxy_right")
        {

            transform.position = pos_left.transform.position;
        }
    }
    #endregion
}
