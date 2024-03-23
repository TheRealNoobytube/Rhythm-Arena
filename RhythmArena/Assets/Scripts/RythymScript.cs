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
    public int misses = 0;
    public Animator animator;
    public GameObject redLine;
    public GameObject canvas;
    public GameObject promptPrefab;
    public GameObject scoreText;
    public GameObject multiplierText;
    public GameObject timeText;


    float timePassed = 0;

    int promptnumber = 0;

    double finishTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        redLine.transform.Find("JKey").transform.position = redLine.transform.position + new Vector3((0 * 2.5f) - 3f, 0, 0);
        redLine.transform.Find("KKey").transform.position = redLine.transform.position + new Vector3((1 * 2.5f) - 3f, 0, 0);
        redLine.transform.Find("LKey").transform.position = redLine.transform.position + new Vector3((2 * 2.5f) - 3f, 0, 0);
        canvas.transform.Find("Background").gameObject.SetActive(false);
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
        print(timePassed);
        //Check that prmopt array is within bounds AND check if enough time has passed to create next prompt 
        while (promptnumber < PromptList.prompts.Length && timePassed >= PromptList.prompts[promptnumber].time - 2.0f)
        {
            //Create instance of prompt in scene
            GameObject promptInstance = Instantiate(promptPrefab, redLine.transform.position, canvas.transform.rotation, canvas.transform);
            promptInstance.GetComponent<PromptController>().canvas = canvas;
            promptInstance.GetComponent<PromptController>().animator = animator;
            promptInstance.GetComponent<PromptController>().targetTime = PromptList.prompts[promptnumber].time - 1.0f;
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
                promptInstance.transform.Translate(new Vector3(0, (Screen.width / 200) * 2f, 0));
                promptInstance.GetComponent<PromptController>().rotate = false;
                promptInstance.transform.Translate(new Vector3(((PromptList.prompts[promptnumber].rowNum) * 2.5f) - 3f, 0, 0));
            }
             

            promptnumber++;
        }

        if (promptnumber == PromptList.prompts.Length)
        {
            finishTimer += Time.deltaTime;

            if (finishTimer > 5)
            {
                scoreText.gameObject.SetActive(false);
                multiplierText.gameObject.SetActive(false);
                canvas.transform.Find("Background").gameObject.SetActive(true);
                canvas.transform.Find("Background").Find("Score").GetComponent<TMP_Text>().text = ("Score: ") + score.ToString();
                canvas.transform.Find("Background").Find("Streak").GetComponent<TMP_Text>().text = ("Streak: ") + multiplier.ToString();
                canvas.transform.Find("Background").Find("Misses").GetComponent<TMP_Text>().text = ("Misses: ") + misses.ToString();
            }
            if (finishTimer > 7)
            {
                canvas.transform.Find("Background").Find("Score").gameObject.SetActive(true);
                
            }
            if (finishTimer > 8)
            {
                canvas.transform.Find("Background").Find("Streak").gameObject.SetActive(true);
            }
            if (finishTimer > 9)
            {
                canvas.transform.Find("Background").Find("Misses").gameObject.SetActive(true);
            }
            if (finishTimer > 10)
            {
                canvas.transform.Find("Background").Find("RankText").gameObject.SetActive(true);
            }
            if (finishTimer > 11)
            {
                RankSprites rank = canvas.transform.Find("Background").Find("Rank").GetComponent<RankSprites>();

                if (score > 10000)
                {
                    rank.renderer.sprite = rank.sprites[4];
                }

                else if (score > 8000)
                {
                    rank.renderer.sprite = rank.sprites[3];
                }

                else if (score > 6000)
                {
                    rank.renderer.sprite = rank.sprites[2];
                }

                else if (score > 4000)
                {
                    rank.renderer.sprite = rank.sprites[1];
                }

                else
                {
                    rank.renderer.sprite = rank.sprites[0];
                }
                canvas.transform.Find("Background").Find("Rank").gameObject.SetActive(true);
            }
        }

    }



}
