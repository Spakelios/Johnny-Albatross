using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
 public GameObject rinkPlayer;
 public GameObject minigameArea;
 public void NewGame()
 {
  SceneManager.LoadScene("ModelTest");
 }

 public void ReturnToRink()
 {
  rinkPlayer.SetActive(true);
  minigameArea.SetActive(false);
 }
}
