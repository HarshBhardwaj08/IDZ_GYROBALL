using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    Color originalColour;
    [SerializeField]Color changecolour = Color.blue;
    private void Start()
    {
        originalColour = GetComponent<SpriteRenderer>().color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = changecolour;
           
          

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
     
        StartCoroutine(change_colour());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator change_colour()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<SpriteRenderer>().color = originalColour;
    }
}
