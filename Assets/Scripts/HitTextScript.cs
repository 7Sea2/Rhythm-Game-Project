using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTextManager : MonoBehaviour
{

    public float lifetime = 1f; //Make sure the text doesn't clog up the hierarchy by deleting it after 1 second

    void Update()
    {
        Destroy(gameObject, lifetime); //Delete after lifetime (1 second), the animation is finished
    }
}
