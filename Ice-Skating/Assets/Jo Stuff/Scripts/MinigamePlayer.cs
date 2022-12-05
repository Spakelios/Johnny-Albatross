using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePlayer : MonoBehaviour
{

    public Animator animator;
    private PDollarDrawingStuffs drawing;
    private bool pick;
    private string[] animations;
    private int pickAnimation;
    private string useAnimation;
    private Animation idle;
    
    private void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();
        drawing = FindObjectOfType<PDollarDrawingStuffs>();
        animations = new[]
        {
            "double axel", "double jump",
            "sit spin", "triple axel"
        };
        
        animator.SetBool("Minigame", true);
        animator.Play("SkateSlow");
    }

    private void OnDisable()
    {
        animator.SetBool("Minigame", false);
    }

    public void PickAnimation()
    {
        pickAnimation = Random.Range(0, animations.Length);
        useAnimation = animations[pickAnimation];
        

        if (useAnimation == animations[0])
        {
            animator.SetTrigger("DAxel");
        }
        
        else if (useAnimation == animations[1])
        {
            animator.SetTrigger("Jump");
        }
        
        else if (useAnimation == animations[2])
        {
            animator.SetTrigger("Spin");
        }

        else
        {
            animator.SetTrigger("TAxel");
        }
    }
}
