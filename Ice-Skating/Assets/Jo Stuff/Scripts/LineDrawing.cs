using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    private Camera mainCamera;
    private Ray ray;
    private List<Vector3> linePoints;

    private LineRenderer line;
    public GameObject newLine;

    public float lineWidth;

    private void Start()
    {
       mainCamera = Camera.main;
       linePoints = new List<Vector3>();
    }
    
    private Vector3 GetMousePosition()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * 10;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            newLine = new GameObject();
            line = newLine.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default"));
            line.startColor = Color.black;
            line.endColor = Color.black;
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            */
            
            newLine = Instantiate(newLine);
            line = newLine.GetComponent<LineRenderer>();
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            

        }
        if (Input.GetMouseButton(0))
        {
            //Debug.DrawRay(mainCamera.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.black);
            linePoints.Add(GetMousePosition());
            line.positionCount = linePoints.Count;
            line.SetPositions(linePoints.ToArray());
        }

        if (Input.GetMouseButtonUp(0))
        {
            linePoints.Clear();
        }
    }
}
