using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    private ParticleSystem finishParticleSystem;
    private GameObject treat;
    [SerializeField] private AudioClip finishSound;
    float finishScore;
    
    void Start()
    { 
        finishParticleSystem = GetComponentInChildren<ParticleSystem>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        treat = GameObject.FindWithTag("TreatCollider");
        finishScore = treat.GetComponent<TreatCollected>().score;
        Debug.Log("finish score = "+finishScore);
        
        if (other.tag == "Player" && finishScore == 15)
        {
            GeneralFinish();
            Invoke("ExecuteSecretLevel",delayTime);
        }
        
        else if (other.tag == "Player")
        {
            GeneralFinish();
            Invoke("ExecuteLevelRestart",delayTime);
        }
    }

    void GeneralFinish ()
    {
        finishParticleSystem.Play();
        GetComponent<AudioSource>().PlayOneShot(finishSound);
    }

    void ExecuteLevelRestart()
    {
        Debug.Log("passed finish line");
        SceneManager.LoadScene("Level_1");
    }

    void ExecuteSecretLevel()
    {
        SceneManager.LoadScene("Level_2");
    }
    
}
