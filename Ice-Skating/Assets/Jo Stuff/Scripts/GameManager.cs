using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canDraw;
    public int roundCooldown;
    private PDollarDrawingStuffs symbolDrawing;
    public int countdown;
    void Start()
    {
        symbolDrawing = FindObjectOfType<PDollarDrawingStuffs>();
        canDraw = false;
        StartCoroutine(ChooseSymbol());
        countdown = 5;
    }

    // Update is called once per frame
    void Update()
    {
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

        symbolDrawing.woah = false;
        canDraw = true;
        symbolDrawing.pickSymbol = Random.Range(0, symbolDrawing.symbols.Length);
        symbolDrawing.useSymbol = symbolDrawing.symbols[symbolDrawing.pickSymbol];
        print(symbolDrawing.useSymbol);
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
            print(":)");
            RestartCountdown();
        }
        
        print(":(");
        RestartCountdown();
    }

    private void RestartCountdown()
    { 
        symbolDrawing.ClearLine();
      StopAllCoroutines();
      StartCoroutine(ChooseSymbol());
    }
    
    
}
