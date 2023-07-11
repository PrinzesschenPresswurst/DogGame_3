using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatCollected : MonoBehaviour
{
    private SpriteRenderer treatSpriteRenderer;
    public float score;
    [SerializeField] AudioClip treatCollectSound;

    private void Start()
    {
        score = 0;
        //treatCollectSound = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Treat")
        {
            treatSpriteRenderer = other.GetComponent<SpriteRenderer>();
            treatSpriteRenderer.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(treatCollectSound);
            score = score + 1;
            Debug.Log("Treats collected: " +score);
        }
           
    }
}

