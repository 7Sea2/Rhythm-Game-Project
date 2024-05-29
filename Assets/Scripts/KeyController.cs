using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    private SpriteRenderer keyRenderer;
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    public KeyCode notePressBind;

    // Start is called before the first frame update
    void Start()
    {
        keyRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(notePressBind)){
            keyRenderer.sprite = pressedSprite;
        }

        if(Input.GetKeyUp(notePressBind)){
            keyRenderer.sprite = defaultSprite;
        }
    }
}
