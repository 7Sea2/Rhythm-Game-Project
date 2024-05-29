using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource stageMusic;
    public bool startPlaying;
    public NoteScroller noteScrollerScript;
    public int currentScore;
    private int scorePerNote = 1000;
    private int scoreMissPenalty = 500;
    public TMP_Text scoreText;
    private Animator anim;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying){
            if(Input.anyKeyDown){
                startPlaying = true;
                noteScrollerScript.hasStarted = true;

                stageMusic.Play();
            }
        }
    }

    public void NoteHit(){
        Debug.Log("Hit");

        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
        anim = scoreText.GetComponent<Animator>();
        anim.Play("ScoreGet", 0, 0.25f);
    }

    public void NoteMissed(){
        Debug.Log("Miss");

        currentScore -= scoreMissPenalty;
    }
}
