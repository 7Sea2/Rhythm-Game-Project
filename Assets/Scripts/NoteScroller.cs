using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{

    public float beatsPerMinute;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatsPerMinute = beatsPerMinute / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted){
            transform.position -= new Vector3(0f, beatsPerMinute * Time.deltaTime, 0f);
        }

    }
}
