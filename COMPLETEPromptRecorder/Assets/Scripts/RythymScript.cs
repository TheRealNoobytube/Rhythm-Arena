using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NUnit.Framework.Internal.Filters;

public class RythymScript : MonoBehaviour
{

    public float score = 0;
    public float multiplier = 0;

    public GameObject redLine;
    public GameObject canvas;
    public GameObject promptPrefab;
    public GameObject scoreText;
    public GameObject multiplierText;
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
        scoreText.GetComponent<Text>().text = "Score : " + score.ToString();
        scoreText.transform.GetChild(0).GetComponent<Text>().text = "Score : " + score.ToString();
        multiplierText.GetComponent<Text>().text = "Multiplier : " + multiplier.ToString();
        multiplierText.transform.GetChild(0).GetComponent<Text>().text = "Multiplier : " + multiplier.ToString();
        timeText.GetComponent<Text>().text = "Time : " + timePassed.ToString();

        timePassed += Time.deltaTime;

        //Check that prmopt array is within bounds AND check if enough time has passed to create next prompt 
        while (promptnumber < PromptList.prompts.Length && timePassed >= PromptList.prompts[promptnumber].time - 1.0f)
        {
            //Create instance of prompt in scene
            GameObject promptInstance = Instantiate(promptPrefab, redLine.transform.position, canvas.transform.rotation, canvas.transform);
            promptInstance.GetComponent<PromptController>().canvas = canvas;
            promptInstance.GetComponent<PromptController>().targetTime = PromptList.prompts[promptnumber].time;
            promptInstance.GetComponent<PromptController>().keyPress = PromptList.prompts[promptnumber].input;
            promptInstance.GetComponent<PromptController>().timePassed = timePassed;

            //Change prompt text
            promptInstance.transform.GetChild(0).GetComponent<TMP_Text>().text = PromptList.prompts[promptnumber].input;

            //Move prompt down
            if (redLine.transform.rotation.z >= 90)
            {
                promptInstance.transform.Translate(new Vector3(+(Screen.width / 200) * 1.0f, 0, 0));
                promptInstance.GetComponent<PromptController>().rotate = true;
                promptInstance.transform.Translate(new Vector3(0, ((-PromptList.prompts[promptnumber].rowNum) * 2.5f) + 2.2f, 0));
            }
            else
            {
                promptInstance.transform.Translate(new Vector3(0, (Screen.width / 200) * 1.0f, 0));
                promptInstance.GetComponent<PromptController>().rotate = false;
                promptInstance.transform.Translate(new Vector3(((PromptList.prompts[promptnumber].rowNum) * 2.5f) - 3f, 0, 0));
            }
             

            promptnumber++;
        }



    }



}
