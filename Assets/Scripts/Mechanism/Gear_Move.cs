using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Move : MonoBehaviour
{
    public GameObject bottom;
    public Transform posA, posB;
    public GameObject bucket;
    public float speed;
    Vector2 targetPos;
    bool ismoving;
    [SerializeField] int ballcount;
    void Start()
    {
        targetPos = posB.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (ismoving == true && ballcount >= 4)
        {
            if (Vector2.Distance(transform.position, posA.position) < .1f)
            {
                targetPos = posB.position;
                bottom.gameObject.SetActive(true);
              

            }
            if (Vector2.Distance(transform.position, posB.position) < .1f)
            {
                targetPos = posA.position;

                bottom.gameObject.SetActive(false);

            }

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            collision.transform.SetParent((bucket.transform));
           
            ismoving = true;
            ballcount++;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        collision.transform.SetParent( null);
    }

}
