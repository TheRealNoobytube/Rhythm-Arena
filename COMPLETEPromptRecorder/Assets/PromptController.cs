using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PromptController : MonoBehaviour
{
    public GameObject canvas;
    public float targetTime;
    public float timePassed;
    public string keyPress;
    public bool canHit = false;

    const float perfectRange = 0f;

    bool missed = false;

    static float lastPressTimeJ;
    static float lastPressTimeK;
    static float lastPressTimeL;

    // Start is called before the first frame update
    void Start()
    {
        targetTime -= perfectRange;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;


        if (timePassed >= targetTime - 0.1f && timePassed <= targetTime + 0.1f)
        {
           gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Perfect";
        }
        else if (timePassed >= targetTime - 0.2f && timePassed <= targetTime + 0.2f)
        {
            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Great";
        }
        else if (timePassed >= targetTime - 0.4f && timePassed <= targetTime + 0.4f)
        {
            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Okay";
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "L";
        }

        //Button is good
        if (Input.GetKeyDown(KeyCode.J) && keyPress.ToLower() == "j" && Time.time > lastPressTimeJ)
        {
            lastPressTimeJ = Time.time;
            checkTiming();
        }
        else if (Input.GetKeyDown(KeyCode.K) && keyPress.ToLower() == "k" && Time.time > lastPressTimeK)
        {
            lastPressTimeK = Time.time;
            checkTiming();
        }
        else if (Input.GetKeyDown(KeyCode.L) && keyPress.ToLower() == "l" && Time.time > lastPressTimeL)
        {
            lastPressTimeL = Time.time;
            checkTiming();
        }



        if (!missed){
            if (timePassed > targetTime + 0.4f)
            {
                canvas.GetComponent<RythymScript>().multiplier = 0;
                missed = true;
               
            }
        }
        if (timePassed > targetTime + 2f)
        {
            Destroy(gameObject);
        }

        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text += " " + missed.ToString();



        transform.Translate(new Vector3(-(Screen.width / 200) * Time.deltaTime, 0, 0));
    }

    public void checkTiming()
    {
        if (!missed)
        {
            //add some leeway so they dont have to be frame perfect
            if (timePassed >= targetTime - 0.1f && timePassed <= targetTime + 0.1f)
            {
                canvas.GetComponent<RythymScript>().score += 100f;
            }
            else if (timePassed >= targetTime - 0.2f && timePassed <= targetTime + 0.2f)
            {
                canvas.GetComponent<RythymScript>().score += 50f;
            }
            else if (timePassed >= targetTime - 0.4f && timePassed <= targetTime + 0.4f)
            {
                canvas.GetComponent<RythymScript>().score += 10f;
            }

            if (timePassed > targetTime + 0.4f)
            {
                canvas.GetComponent<RythymScript>().multiplier = 0;
            }
            else
            {
                canvas.GetComponent<RythymScript>().multiplier++;
            }

            Destroy(gameObject);
        }

    }

    //random stuff might need later probably probably not
    //if (Input.GetKeyDown((KeyCode) System.Enum.Parse(typeof(KeyCode), keyPress.ToLower(), true)))
}
