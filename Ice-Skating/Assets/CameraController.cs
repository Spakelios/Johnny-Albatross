using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
  // Variables
  [SerializeField] private float mouseSensitivity;
  

  // References
  private Transform parent;

  private void Start()
  {
    parent = transform.parent;
    Cursor.lockState = CursorLockMode.Locked;
  }

  private void OnEnable()
  {
      Cursor.lockState = CursorLockMode.Locked;
  }

  private void Update()
  {
   rotate(); 
  }

  private void rotate()
  {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      
      parent.Rotate(Vector3.up , mouseX);

  }
}
