using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPixelsTest : MonoBehaviour
{
    public Texture2D image;
    private int blackPixels;
    private int noPixels;
    
    private void Start()
    {
        image = gameObject.GetComponent<Image>().sprite.texture;
        ReadPixel();
    }

    private void ReadPixel()
    {
        for (var i = 0; i < image.width; i++)
        {
            for (var j = 0; j < image.height; j++)
            {
                var pixel = image.GetPixel(i, j);

                if (pixel == Color.black)
                {
                    blackPixels++;
                }

                else
                {
                    noPixels++;
                }
            }
        }
        
        Debug.Log("Black pixels: " + blackPixels + ", Clear pixels: " + noPixels);

    }
}
