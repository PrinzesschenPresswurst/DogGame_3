using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField]  float rotationSpeed = 20f;
    private Rigidbody2D rb2d;
    
    private SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 25;
    float initialBoostSpeed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        initialBoostSpeed = surfaceEffector2D.speed;
    }

    void Update()
    {
        ControlPlayer();
        RespondToBoost();
    }

    void ControlPlayer()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                // Rotate counter-clockwise
                rb2d.AddTorque(rotationSpeed);
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                // Rotate clockwise
                rb2d.AddTorque(-rotationSpeed);
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }

        } 
    }


    void RespondToBoost()
    {

        if (Input.touchCount == 2)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        
        else
        {
            surfaceEffector2D.speed = initialBoostSpeed;
        }
    }
}

