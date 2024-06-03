using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    private SpriteRenderer keyRenderer;
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    public KeyCode notePressBind;

    void Start()
    {
        keyRenderer = GetComponent<SpriteRenderer>(); //We change the spriterenderer in this script
    }

    void Update()
    {
        if(Input.GetKeyDown(notePressBind)){ //Detect if player pressed d, f, j or k key
            keyRenderer.sprite = pressedSprite; //Replace sprite with the pressed sprite (darkened)
        }

        if(Input.GetKeyUp(notePressBind)){ //Detect if key is let go
            keyRenderer.sprite = defaultSprite; //Revert to the default sprite (not darkened)
        }
    }
}
