using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 2.0f;
    public float moveSpeedDouble = 3.0f;
    public float moveSpeedTriple = 3.5f;
    public float jumpSpeed = 7.0f;
    public float leeway = 0.1f;

    float jPressed;
    float kPressed;
    float lPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = rb.velocity;

        jPressed = CheckInput(KeyCode.J) != -1 ? CheckInput(KeyCode.J) : jPressed;
        kPressed = CheckInput(KeyCode.K) != -1 ? CheckInput(KeyCode.K) : kPressed;
        lPressed = CheckInput(KeyCode.L) != -1 ? CheckInput(KeyCode.L) : lPressed;

        int numberPressed = 0;
        if (jPressed > 0) numberPressed++;

        if (kPressed > 0) numberPressed++;

        if (lPressed > 0) numberPressed++;

        switch(numberPressed)
        {
            case 0:
                //movement.x = 0f;
                break;
            case 1:
                movement.x = moveSpeed;
                break;
            case 2:
                movement.x = moveSpeedDouble;
                break;
            case 3:
                movement.x = moveSpeedTriple;
                break;
        }

        rb.velocity = movement;

        jPressed -= Time.deltaTime;
        kPressed -= Time.deltaTime;
        lPressed -= Time.deltaTime;
        /*if (jPressed > 0 | kPressed > 0 | lPressed > 0){
            movement.x = moveSpeed;
        }
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.J) && (Input.GetKeyDown(KeyCode.K)))
        {
            movement.x = moveSpeedDouble;

        }
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.K) && (Input.GetKeyDown(KeyCode.L)))
        {
            movement.x = moveSpeedDouble;

        }
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.J) && (Input.GetKeyDown(KeyCode.K) && (Input.GetKeyDown(KeyCode.L))))
        {
            movement.x = moveSpeedTriple;
        }
        rb.velocity = movement;*/

    }

    float CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key)) return leeway;
        return -1;
    }


}
