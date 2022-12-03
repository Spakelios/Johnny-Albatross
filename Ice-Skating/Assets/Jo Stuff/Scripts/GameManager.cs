using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool canDraw;
    public int roundCooldown;
    private PDollarDrawingStuffs symbolDrawing;
    public int countdown;
    private int[] points;
    private int totalPoints;
    public TextMeshProUGUI total;
    public TextMeshProUGUI status;
    public TextMeshProUGUI symbol;
    public int roundNumber;
    public GameObject panel;
    
    void Start()
    {
        symbolDrawing = FindObjectOfType<PDollarDrawingStuffs>();
        canDraw = false;
        countdown = 5;
        points = new[]
        {
            50, 100,
            250, 500, 750
        };

        totalPoints = 0;
        status.text = "";
        symbol.text = "";
        panel.SetActive(false);
        
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
        roundNumber += 1;
        symbolDrawing.woah = false;
        canDraw = true;
        symbolDrawing.pickSymbol = Random.Range(0, symbolDrawing.symbols.Length);
        symbolDrawing.useSymbol = symbolDrawing.symbols[symbolDrawing.pickSymbol];
        symbol.text = symbolDrawing.useSymbol;
        StartCoroutine(DrawSymbol());
    }

    private IEnumerator DrawSymbol()
    {
        countdown = 5;
        
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);
            countdown--;

            if (!symbolDrawing.woah) continue;
            CalculatePoints();
        }
        
        status.text = "Bad...";
        totalPoints += points[0];
        RestartCountdown();
    }

    private void CalculatePoints()
    {
        
        //print(symbolDrawing.gestureResult.Score);

        if (symbolDrawing.gestureResult.Score >= 0.95f)
        {
            status.text = "Amazing!";
            totalPoints += points[4];
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.9f)
        {
            status.text = "Great!";
            totalPoints += points[3];
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.85f)
        {
            status.text = "Good!";
            totalPoints += points[2];
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.6f)
        {
            status.text = "OK";
            totalPoints += points[1];
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
