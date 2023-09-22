using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(restarts());
    }
    IEnumerator restarts()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(0);
    }
}
