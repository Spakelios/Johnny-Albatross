using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject interactButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);
    }
}
