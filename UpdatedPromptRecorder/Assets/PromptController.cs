using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PromptController : MonoBehaviour
{
    public GameObject canvas;
    public float targetTime;
    public float timePassed;
    public string keyPress;
    public bool canHit = false;

    const float perfectRange = 0.5f;

    bool missed = false;
    // Start is called before the first frame update
    void Start()
    {
        targetTime -= perfectRange;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        checkCanHit(gameObject.transform.position);

        if (canHit){

            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), keyPress.ToLower(), true))){
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

        if (!missed){
            if (timePassed > targetTime + 0.4f){
                canvas.GetComponent<RythymScript>().multiplier = 0;
                missed = true;
                Destroy(gameObject);
            }
        }


        

        transform.Translate(new Vector3(-(Screen.width / 200) * Time.deltaTime, 0, 0));
    }


    public void checkCanHit(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.left);


        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "RedLine")
            {
                Debug.DrawRay(position, Vector2.left * hit.distance, Color.red, Mathf.Infinity, true);
                canHit = true;
            }
            else
            {
                canHit = false;
            }
                

        }
        else
        {
            Debug.DrawRay(position, Vector2.left * 1000, Color.yellow, Mathf.Infinity, true);
            canHit = false;
        }
    }

}
