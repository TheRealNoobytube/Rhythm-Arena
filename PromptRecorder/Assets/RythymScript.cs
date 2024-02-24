using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.UI;

public class RythymScript : MonoBehaviour
{
    

    public GameObject canvas;
    public GameObject promptPrefab;
    public GameObject timeText;


    float timePassed = 0;

    int promptnumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.GetComponent<Text>().text = "Time : " + timePassed.ToString();
        timePassed += Time.deltaTime;
        
        //Check that prmopt array is within bounds AND check if enough time has passed to create next prompt 
        while (promptnumber < PromptList.prompts.Length && timePassed >= PromptList.prompts[promptnumber].time - 1.8f) 
        {
            //Create instance of promopt in scene
            GameObject promptInstance = Instantiate( promptPrefab, canvas.transform);

            //Change prompt text
            promptInstance.transform.GetChild(0).GetComponent<TMP_Text>().text = PromptList.prompts[promptnumber].input;

            //Move prompt down
            promptInstance.transform.Translate(new Vector3(0, -PromptList.prompts[promptnumber].rowNum) * 2.5f, 0);

            promptnumber++;
        }
        print(timePassed);



    }



}
