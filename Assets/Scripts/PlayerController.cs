using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 2;
    
    private SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 25;
    float initialBoostSpeed;
    
    [SerializeField] ParticleSystem slideParticles;
    private ParticleSystem.MainModule slideParticleColorSettings;
    private Color yourColor = Color.yellow;
    private ParticleSystem.MinMaxGradient initialColor;
    [SerializeField] private AudioSource boostSound;
    public bool canMove = true;
    
    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        initialBoostSpeed = surfaceEffector2D.speed;
        initialColor = slideParticles.GetComponent<ParticleSystem>().main.startColor;
        slideParticleColorSettings = slideParticles.GetComponent<ParticleSystem>().main;
    }

    void Update()
    {
        if (canMove == true)
        {
            ControlPlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        Debug.Log("Controls Disabled");
        canMove = false;
        rb2d.simulated = false;
    }

    void ControlPlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boostSound.Play();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
            slideParticleColorSettings.startColor = yourColor;
        }
        
        else
        {
            surfaceEffector2D.speed = initialBoostSpeed;
            slideParticleColorSettings.startColor = initialColor;
        }
    }
}
