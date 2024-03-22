using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgementPopup : MonoBehaviour
{

    private float timer;
    public SpriteRenderer judgement;
    public Sprite[] sprites;

    void Start()
    {
        
        judgement = transform.Find("Judgement").GetComponent<SpriteRenderer>();
        
    }



    void Update()
    {
        
        timer += Time.deltaTime;
        transform.Translate(new Vector3(0, -(Screen.width / 180) * Time.deltaTime, 0));
        
        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
