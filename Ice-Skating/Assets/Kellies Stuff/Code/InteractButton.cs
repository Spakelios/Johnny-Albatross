using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject start;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
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
    }
}
