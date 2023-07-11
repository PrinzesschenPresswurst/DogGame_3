using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogMover : MonoBehaviour
{
    private float xMove;

    [SerializeField] float speed = 2;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(xMove,0,0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            xMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(xMove,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ReplayBox")
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
