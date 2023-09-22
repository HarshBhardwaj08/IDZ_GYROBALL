using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Animator anim;
   [SerializeField] GameObject bubble;
   [SerializeField] Color changecolour = Color.blue;
    private Camera cam;
    [SerializeField] int count;
    [SerializeField] List<GameObject> allBubbles = new List<GameObject>();
    Ray ray;
    RaycastHit2D hit;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        allBubbles.AddRange(bubbles);
        cam = Camera.main;
    }


    void Update()
    {

      

    }
    private void OnMouseDown()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        // Perform a raycast and store the hit information.
        hit = Physics2D.GetRayIntersection(ray);
        // Check for mouse click.
        anim.SetBool("isSqueze", true);
            StartCoroutine(animation_disable());

     }
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("isSqueze", true);
            bubble.gameObject.GetComponent<SpriteRenderer>().color = changecolour;
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(animation_disable());          
        }
    }

    IEnumerator animation_disable()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isSqueze", false);
    }
    

}
