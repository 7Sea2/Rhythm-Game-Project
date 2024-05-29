using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    private bool hitSuccess = false;
    public KeyCode noteActivateBind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(noteActivateBind) && canBePressed == true){

            GameManager.instance.NoteHit();
            hitSuccess = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){

            canBePressed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Activator"){

            canBePressed = false;

            if(hitSuccess == false){

                GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f,0.4f);

                GameManager.instance.NoteMissed();
            }
        }
    }
}
