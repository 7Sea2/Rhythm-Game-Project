using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{

    public float beatsPerMinute;

    public bool hasStarted;

    void Start()
    {
        //The beats per minute get divided by 60
        //This calculates the beats per second (minute/60 = seconds)
        //This also dictates the speed the notes move
        beatsPerMinute = beatsPerMinute / 60f;
    }

    void Update()
    {
        if(hasStarted){ //Waits until player has pressed any key
            transform.position -= new Vector3(0f, beatsPerMinute * Time.deltaTime, 0f); //Moves the notes down at a set rate
        }

    }
}
