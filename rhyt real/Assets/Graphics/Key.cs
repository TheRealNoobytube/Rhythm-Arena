using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //check if any arrows can be pressed
            if (GameObject.FindGameObjectsWithTag("canPress").Length > 0) {

                //destroy the first arrow in the tag canPress
                Destroy(GameObject.FindGameObjectsWithTag("canPress")[0]);
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when an arrow enters the key, give it the tag canPress
        collision.gameObject.tag = "canPress";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when an arrow leaves the key, give it the tag canPress
        collision.gameObject.tag = "Untagged";
            
    }
}
