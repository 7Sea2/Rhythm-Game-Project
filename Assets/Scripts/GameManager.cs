using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource stageMusic;
    public bool startPlaying = false;
    public int currentScore;

    private int scoreMissPenalty = 1000;
    private int scoreNormalNote = 1000;
    private int scoreGoodNote = 2000;
    private int scorePerfectNote = 3000;
    public TMP_Text scoreText;
    private Animator scoreAnim;
    public GameObject creditsAndControls;

    public NoteScroller noteScrollerScript;
    public static GameManager instance; //The GameManager does most things, this lets another script instantialize it
    private float totalNotes;
    private float normalHits;
    private float goodHits;
    private float perfectHits;
    private float missedHits;

    public GameObject resultsScreen;
    public TMP_Text percentResult, missResult, normalResult, goodResult, perfectResult, rankResult, finalScoreResult;

    void Start()
    {
        instance = this; //Set this script as the instance

        totalNotes = FindObjectsOfType<NoteObject>().Length; //Set the variable to the amount of notes in the scene, makes it so you don't have to input it manually
    }

    void Update()
    {
        if(!startPlaying && Input.anyKeyDown){ //It's important to use the "startPlaying" variable so the music doesn't start over EVERY time you press a key

            startPlaying = true; //Start game when any key is pressed
            noteScrollerScript.hasStarted = true; //Also notify the noteControllerScript that any key has been pressed
            Destroy(creditsAndControls); //This screen makes it so i don't have to make a "controls" menu option
            stageMusic.Play(); //Start the music (is a AudioSource variable object)
        }else{
            if(stageMusic.time >= 20 && !resultsScreen.activeInHierarchy){ //After 20 seconds the notes stop (i ran out of time to add more)
                resultsScreen.SetActive(true);

                //Set all the values of the text in the results screen
                normalResult.text = normalHits.ToString();
                goodResult.text = goodHits.ToString();
                perfectResult.text = perfectHits.ToString();
                missResult.text = missedHits.ToString();
                finalScoreResult.text = currentScore.ToString();

                float totalHit = normalHits + goodHits + perfectHits; //Calculate the total of notes hit
                float percentHit = (totalHit / totalNotes) * 100; //Standard calculation for percentage
                percentResult.text = percentHit.ToString("F1") + "%"; //"F1" displays the float with 1 decimal

                //Checks the percentage of hit notes and dictates a rank based off that
                string rankVal = "D";
                if(percentHit >= 40){rankVal = "C";}
                if(percentHit >= 60){rankVal = "B";}
                if(percentHit >= 80){rankVal = "A";}
                if(percentHit >= 95){rankVal = "S";}
                
                rankResult.text = rankVal;
            }
        }
    }

    //ALL THE NEXT FUNCTIONS GET CALLED IN THE NoteObjectScript

    public void NoteHit(){
        scoreText.text = "Score: " + currentScore; //Live update the score on the top right of the screen
        scoreAnim = scoreText.GetComponent<Animator>();
        scoreAnim.Play("ScoreGet", 0, 0.25f); //Make the score text play an animation because it looks cool
    }

    public void NormalHit(){
        currentScore += scoreNormalNote; //Add the score that the global variable dictates to the total
        NoteHit();
        normalHits++; //Add 1 to the amount of notes hit, so that it can be displayed in the results screen
    }

    public void GoodHit(){
        currentScore += scoreGoodNote;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit(){
        currentScore += scorePerfectNote;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed(){
        currentScore -= scoreMissPenalty;
        //Debug.Log("Miss");
        missedHits++;
    }
}
