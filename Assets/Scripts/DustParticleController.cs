using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem slideParticles;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            slideParticles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            slideParticles.Stop(); 
        }
    }
}
