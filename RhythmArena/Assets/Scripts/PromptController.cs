using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{

    bool debug = false;

    public GameObject canvas;
    public Animator animator;

    GameObject portal;

    public float targetTime;
    public float timePassed;
    public string keyPress;
    public bool canHit = false;
    public bool rotate = false;
    const float correction = 0.1f;
    const float perfectRange = -1.08f;
    const float midRange = 0.2f;
    const float edgeRange = 0.4f;


    bool missed = false;

    static float lastPressTimeJ;
    static float lastPressTimeK;
    static float lastPressTimeL;

    SpriteRenderer enabledPrompt;



    // Start is called before the first frame update
    void Start()
    {

        portal = GameObject.FindWithTag("portal");

        targetTime -= perfectRange;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "";

        if (keyPress.ToLower() == "j")
        {
            enabledPrompt = gameObject.transform.Find("JPrompt").GetComponent<SpriteRenderer>();

        }
        else if (keyPress.ToLower() == "k")
        {
            enabledPrompt = gameObject.transform.Find("KPrompt").GetComponent<SpriteRenderer>();
        }
        else if (keyPress.ToLower() == "l")
        {
            enabledPrompt = gameObject.transform.Find("LPrompt").GetComponent<SpriteRenderer>();
        }

        enabledPrompt.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (debug)
        {
            if (timePassed >= targetTime - 0.1f && timePassed <= targetTime + 0.1f - correction)
            {
                gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Perfect";
            }
            else if (timePassed >= targetTime - midRange && timePassed <= targetTime + midRange - correction)
            {
                gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Great";
            }
            else if (timePassed >= targetTime - edgeRange && timePassed <= targetTime + edgeRange - correction)
            {
                gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Okay";
            }
            else
            {
                gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "L";
            }

        }


        //Button is good
        if (!missed)
        {
            if (Input.GetKeyDown(KeyCode.J) && keyPress.ToLower() == "j" && Time.time > lastPressTimeJ)
            {
                lastPressTimeJ = Time.time;
                checkTiming();
                animator.SetTrigger("Attack");
                
            }
            else if (Input.GetKeyDown(KeyCode.K) && keyPress.ToLower() == "k" && Time.time > lastPressTimeK)
            {
                lastPressTimeK = Time.time;
                checkTiming();
                animator.SetTrigger("Attack");
            }
            else if (Input.GetKeyDown(KeyCode.L) && keyPress.ToLower() == "l" && Time.time > lastPressTimeL)
            {
                lastPressTimeL = Time.time;
                checkTiming();
                animator.SetTrigger("Attack");
            }
            
        }


        if (!missed){
            if (timePassed > targetTime + edgeRange)
            {
                enabledPrompt.color = new Color(0.355f, 0.355f, 0.355f, 1);
                canvas.GetComponent<RythymScript>().multiplier = 0;
                canvas.GetComponent<RythymScript>().misses++;
                missed = true;


                Object popupPrefabPath = Resources.Load("Prefabs/judgementText");
                GameObject popupInstance = Instantiate(popupPrefabPath, canvas.transform) as GameObject;
                popupInstance.transform.position += new Vector3(-3, 0, 0);
                JudgementPopup popupText = popupInstance.GetComponent<JudgementPopup>();
                popupText.judgement.sprite = popupText.sprites[3];
                /*animator.SetBool("isAttacking", false);*/
            }
        }

        if (timePassed > targetTime + 2f)
        {
            Destroy(gameObject);
        }

        //gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text += " " + missed.ToString();


        if (rotate)
        {
            transform.Translate(new Vector3(-5.5f * Time.deltaTime, 0, 0));

        }
        else
        {
            transform.Translate(new Vector3(0, -5.5f * Time.deltaTime, 0));
        }
        
    }

    public void checkTiming()
    {
        bool deleteObject = true;

        Object popupPrefabPath = Resources.Load("Prefabs/judgementText");
        GameObject popupInstance = Instantiate(popupPrefabPath , canvas.transform) as GameObject;
        popupInstance.transform.position += new Vector3(-3, 0, 0);
        JudgementPopup popupText = popupInstance.GetComponent<JudgementPopup>();


        //popupInstance.transform.SetParent(canvas.GetComponent<RythymScript>().redLine.transform);

        bool hit = false;

        //add some leeway so they dont have to be frame perfect
        if (timePassed >= targetTime - 0.15f && timePassed <= targetTime + 0.15f - correction)
        {
            canvas.GetComponent<RythymScript>().score += 100f;
            popupText.judgement.sprite = popupText.sprites[0];
            hit = true;
        }
        else if (timePassed >= targetTime - midRange && timePassed <= targetTime + midRange - correction)
        {
            canvas.GetComponent<RythymScript>().score += 50f;
            popupText.judgement.sprite = popupText.sprites[1];
            hit = true;
        }
        else if (timePassed >= targetTime - edgeRange && timePassed <= targetTime + edgeRange - correction)
        {
            canvas.GetComponent<RythymScript>().score += 10f;
            popupText.judgement.sprite = popupText.sprites[2];
            hit = true;
        }

        if (hit == true)
        {
            portal.transform.localScale += new Vector3(0.1f, 0.08f, 0.0f);
        }


        if (timePassed < targetTime - edgeRange || timePassed > targetTime + edgeRange - correction)
        {
            missed = true;
            deleteObject = false;
            enabledPrompt.color = new Color(0.355f, 0.355f, 0.355f, 1);
            canvas.GetComponent<RythymScript>().multiplier = 0;
            canvas.GetComponent<RythymScript>().misses++;

            popupText.judgement.sprite = popupText.sprites[3];
        }
        else
        {
            canvas.GetComponent<RythymScript>().multiplier++;
        }

        if (deleteObject)
        {
            Destroy(gameObject);
        }
        
       

    }

    //random stuff might need later probably probably not
    //if (Input.GetKeyDown((KeyCode) System.Enum.Parse(typeof(KeyCode), keyPress.ToLower(), true)))
}
