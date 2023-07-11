using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    //private Rigidbody2D rb2d;
    private SpriteRenderer renderer;
    private ParticleSystem crashParticleSystem;
    [SerializeField] private AudioClip crashSound;
    private bool hasCrashed;

    void Start()
    { 
        //rb2d = GetComponentInParent<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        crashParticleSystem = GetComponentInChildren<ParticleSystem>();
        hasCrashed = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            renderer.color= Color.red;
            crashParticleSystem.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);

            Invoke("ExecuteLevelLoss", delayTime);
            hasCrashed = true;
        }
    }

    void ExecuteLevelLoss()
    {
        Debug.Log("bumped head");
        SceneManager.LoadScene("Level_1");
    }
}
