using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RythymScript : MonoBehaviour
{
    


    struct Prompt
    {
        public float time;
        public string input;
    }

    Prompt[] prompts = 
    {
        new Prompt { time = 4, input = "j"},
        new Prompt { time = 6, input = "k"},
        new Prompt { time = 8, input = "j"},
        new Prompt { time = 10, input = "k"},
    };


    public GameObject canvas;
    public GameObject promptprefab;


    float timePast = 0;

    int promptnumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePast += Time.deltaTime;

        if (timePast >= prompts[promptnumber].time - 3) 
        {
            GameObject promptobj = Instantiate( promptprefab, canvas.transform);

            promptobj.transform.GetChild(0).gameObject.SetActive(false);

            promptnumber++;
        }
    }
}
