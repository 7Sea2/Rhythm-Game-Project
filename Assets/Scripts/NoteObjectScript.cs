using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    private bool hitSuccess = false;
    public KeyCode noteActivateBind;
    public GameObject missText, hitText, goodText, perfectText;
    public ParticleSystem perfectParticle;

    void Update()
    {
        if(Input.GetKeyDown(noteActivateBind) && canBePressed == true){

            /*GameManager.instance.NoteHit();
            hitSuccess = true;
            Destroy(gameObject);*/


            //This garbage code checks for the distance of the note from the middle
            //Since the keys are at Y position 0, it can detect the distance from Y=0
            if(Mathf.Abs(transform.position.y) > 0.60){
                GameManager.instance.NormalHit(); //GO TO SCRIPT GAME MANAGER NormalHit() FUNCTION
                hitSuccess = true; //If this wasn't here it'd count as a miss since the object gets deleted and that'd mean it leaves the hitbox
                //Debug.Log("hit");
                Instantiate(hitText, transform.position, hitText.transform.rotation); //Create copy of the hit text prefab to give feedback to player
                Destroy(gameObject);
            } else if(Mathf.Abs(transform.position.y) > 0.15){
                GameManager.instance.GoodHit();
                hitSuccess = true;
                //Debug.Log("good");
                Instantiate(goodText, transform.position, goodText.transform.rotation);
                Destroy(gameObject);
            } else{
                GameManager.instance.PerfectHit();
                hitSuccess = true;
                //Debug.Log("perfect");
                Instantiate(perfectText, transform.position, perfectText.transform.rotation);
                perfectParticle.Play();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){ //Unity tag system, the keys have this tag

            canBePressed = true; //This is important
            //When in the hitbox of the key, this is true so that the script knows the note is in the right position

        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Activator"){

            canBePressed = false; //When you missed it, you cannot hit anymore

            if(hitSuccess == false){ //Make SURE that the note DIDN'T GET HIT and DIDN'T JUST GET DELETED

                GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f,0.4f); //Transparency effect when you miss because it looks good

                GameManager.instance.NoteMissed(); //GO TO SCRIPT GAME MANAGER NoteMissed() FUNCTION
                Instantiate(missText, transform.position, missText.transform.rotation); //Create copy of the miss text prefab so the player knows they messed up
            }
        }
    }
}
