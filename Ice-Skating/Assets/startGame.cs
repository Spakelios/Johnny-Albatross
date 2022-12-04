using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public GameObject Cam2;
    public GameObject cam1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cam2.SetActive(true);
            cam1.SetActive(false);
        }
    }
}
