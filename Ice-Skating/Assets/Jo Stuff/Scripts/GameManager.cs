using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool canDraw;
    public int roundCooldown;
    public PDollarDrawingStuffs symbolDrawing;
    public int countdown;
    private int[] points;
    private int totalPoints;
    public TextMeshProUGUI total;
    public TextMeshProUGUI status;
    public TextMeshProUGUI symbol;
    public int roundNumber;
    public GameObject panel;
    public MinigamePlayer player;
    private int pickSymbol;
    public string useSymbol;
    public string[] symbols;

    private void Awake()
    {
        points = new[]
        {
            50, 100,
            250, 500, 750
        };
    }
    
    private void OnEnable()
    {
        //symbolDrawing = FindObjectOfType<PDollarDrawingStuffs>();
        canDraw = false;
        countdown = 5;
        
        roundNumber = 1;
        totalPoints = 0;
        status.text = "";
        symbol.text = "";
        panel.SetActive(false);
        //player = FindObjectOfType<MinigamePlayer>();

        //StartCoroutine(ChooseSymbol());
    }

    public void DoIt()
    {
        StartCoroutine(ChooseSymbol());
    }

    // Update is called once per frame
    void Update()
    {
        total.text = "Total Points: " + totalPoints;
        
    }

    private IEnumerator ChooseSymbol()
    {
        roundCooldown = Random.Range(5, 10);
        
        while (roundCooldown > 0)
        {
            canDraw = false;
            yield return new WaitForSeconds(1f);
            roundCooldown--;
        }
        
        status.text = "";
        symbolDrawing.woah = false;
        canDraw = true;
        pickSymbol = Random.Range(0, symbols.Length);
        useSymbol = symbols[pickSymbol];
        symbol.text = useSymbol;
        StartCoroutine(DrawSymbol());
    }

    private IEnumerator DrawSymbol()
    {
        countdown = 5;
        
        while (countdown > 0 && symbolDrawing.woah == false)
        {
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        
        status.text = "Bad...";
        totalPoints += points[0];
        RestartCountdown();
    }

    public void CalculatePoints()
    {

        if (symbolDrawing.gestureResult.Score >= 0.95f)
        {
            status.text = "Amazing!";
            totalPoints += points[4];
            player.PickAnimation();
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.9f)
        {
            status.text = "Great!";
            totalPoints += points[3];
            player.PickAnimation();
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.85f)
        {
            status.text = "Good!";
            totalPoints += points[2];
            player.PickAnimation();
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.6f)
        {
            status.text = "OK";
            totalPoints += points[1];
            player.PickAnimation();
        }
        
        RestartCountdown();
    }

    private void RestartCountdown()
    {
        symbol.text = "";
        symbolDrawing.ClearLine();
      StopAllCoroutines();

      if (roundNumber < 5)
      {
          StartCoroutine(ChooseSymbol());
          roundNumber += 1;
      }

      else
      {
          FinalScore();
      }
    }

    private void FinalScore()
    {
        status.text = "";
        panel.SetActive(true);
    }
}
