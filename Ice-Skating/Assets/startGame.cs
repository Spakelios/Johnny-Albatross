using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public GameObject Cam2;
    public GameObject cam1;
    public GameObject start;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            start.SetActive(true);
        }
    }

    private void Update()
    {
        if (start == isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Cam2.SetActive(true);
                cam1.SetActive(false);
            }
        }
    }
}
