using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public Arrow arrow;
    public float spread = 0.02f;

    void Start()
    {
        for (float i = 0; i < 20; i++)
        {
            SpawnArrow(transform.position - new Vector3(0, i * spread, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnArrow(Vector3 position)
    {
        Arrow newArrow = Instantiate(arrow, position, Quaternion.Euler(0f, 0f, 90f));
        newArrow.Speed = 50f;
    }

}
