using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using PDollarGestureRecognizer;

public class PDollarDrawingStuffs : MonoBehaviour
{
	public Transform gestureOnScreenPrefab;
	private List<Gesture> trainingSet = new List<Gesture>();
	private List<Point> points = new List<Point>();
	private int strokeId = -1;
	public Vector3 virtualKeyPosition = Vector2.zero;
	private Rect drawArea;
	private RuntimePlatform platform;
	private int vertexCount = 0;
	private List<LineRenderer> gestureLinesRenderer = new List<LineRenderer>();
	private LineRenderer currentGestureLineRenderer;
	private bool recognized;
	public bool woah;
	//public int pickSymbol;
	//public string useSymbol;
	public Result gestureResult;

	//public string[] symbols;
	public GameManager gameManager;

	public Camera camera;

	private void Awake()
	{
		//Load pre-made gestures
		TextAsset[] gesturesXml = Resources.LoadAll<TextAsset>("GestureSet/10-stylus-MEDIUM/");
		foreach (TextAsset gestureXml in gesturesXml)
			trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));
		//Load user custom gestures
		
		/*
		string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.xml");
		foreach (string filePath in filePaths)
			trainingSet.Add(GestureIO.ReadGestureFromFile(filePath));
			*/
		
		TextAsset[] customGesturesXml = Resources.LoadAll<TextAsset>("GestureSet/Custom-Gestures/");
		foreach (TextAsset gestureXml in customGesturesXml)
			trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));
	}

	
	private void OnEnable()
	{
		//gameManager = FindObjectOfType<GameManager>();
		//platform = Application.platform;
		
		drawArea = new Rect(0, 0, Screen.width - Screen.width / 2, Screen.height);
		
		woah = false;

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Vector2 mousePos = Input.mousePosition;
		mousePos.x = 0;
		mousePos.y = 0;
		
		gameManager.DoIt();
	}

private void Update()
{
	
	if (!gameManager.canDraw) return;
	
	if (Input.GetMouseButton(0))
	{
		virtualKeyPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
	}
	
	if (drawArea.Contains(virtualKeyPosition)) {
		if (Input.GetMouseButtonDown(0)) {
			if (recognized) {
				recognized = false;
				strokeId = -1;
				points.Clear();
				foreach (LineRenderer lineRenderer in gestureLinesRenderer) {
					lineRenderer.SetVertexCount(0);
					Destroy(lineRenderer.gameObject);
				}
				gestureLinesRenderer.Clear();
			}
			++strokeId;
				
			Transform tmpGesture = Instantiate(gestureOnScreenPrefab, transform.position, transform.rotation) as Transform;
			currentGestureLineRenderer = tmpGesture.GetComponent<LineRenderer>();
				
			gestureLinesRenderer.Add(currentGestureLineRenderer);
				
			vertexCount = 0;
		}
			
		if (Input.GetMouseButton(0)) {
			points.Add(new Point(virtualKeyPosition.x, -virtualKeyPosition.y, strokeId));
			currentGestureLineRenderer.SetVertexCount(++vertexCount);
			currentGestureLineRenderer.SetPosition(vertexCount - 1, camera.ScreenToWorldPoint(new Vector3(virtualKeyPosition.x, virtualKeyPosition.y, 10)));
			
		}

		if (Input.GetMouseButtonUp(0))
		{
			
			TryRecognize();
			
		}
	}
}

private void TryRecognize()
	{
		if (points.Count <= 0)
			return;
		if (recognized)
			ClearLine();
		recognized = true;
		Gesture candidate = new Gesture(points.ToArray());

		gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());
		
		if (gestureResult.Score < .6f)
		{
			ClearLine();
			return;
		}

		if (gestureResult.GestureClass == gameManager.useSymbol)
		{

			woah = true;
			gameManager.CalculatePoints();

			if (recognized)
			{
				recognized = false;
				strokeId = -1;

				points.Clear();

				foreach (LineRenderer lineRenderer in gestureLinesRenderer)
				{
					lineRenderer.SetVertexCount(0);
					Destroy(lineRenderer.gameObject);
				}
				gestureLinesRenderer.Clear();
			}
			
		}

		else
		{
			ClearLine();
			woah = false;
		}
	}


	public void ClearLine()
	{
		recognized = false;
		strokeId = -1;
		points.Clear();
		foreach (LineRenderer lineRenderer in gestureLinesRenderer)
		{
			lineRenderer.positionCount = 0;
			Destroy(lineRenderer.gameObject);
		}
		gestureLinesRenderer.Clear();
	}
}

