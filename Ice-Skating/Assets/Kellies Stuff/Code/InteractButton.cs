using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject start;
    public AudioSource rink;
    public AudioSource bonnie;
    public AudioSource jeannie;
    public AudioSource johnny;

    private void Start()
    {
        bonnie.Stop();
        jeannie.Stop();
        johnny.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonnie"))
        {
            interactButton.SetActive(true);
            rink.Stop();
            bonnie.Play();
        }
        
        if (other.CompareTag("Jeannie"))
        {
            interactButton.SetActive(true);
            rink.Stop();
            jeannie.Play();
        }
        
        if (other.CompareTag("Johnny"))
        {
            interactButton.SetActive(true);
            rink.Stop();
            johnny.Play();
            
        }
        
        if (other.CompareTag("Eagles"))
        {
            interactButton.SetActive(true);
        }
        
        if(other.CompareTag("Block"))
        {
            start.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);
        start.SetActive(false);
        bonnie.Stop();
        johnny.Stop();
        jeannie.Stop();
        rink.Play();
    }
}
