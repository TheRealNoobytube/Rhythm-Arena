using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Melanchall.DryWetMidi;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public float songDelayInSeconds;
    public int inputDelayInMilliseconds;

    public string filelocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
