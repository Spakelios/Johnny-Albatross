using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayHello : MonoBehaviour
{
    public GameObject talk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talk.SetActive(true);
            print("Its Johnny");
        }
    }
}
