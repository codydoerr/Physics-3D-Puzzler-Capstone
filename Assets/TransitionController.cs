using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    MainMenuController mmc;
    public GameObject endgame;

    public void LoadNextScene()
    {
       endgame.GetComponent<EndGame>().GoToNextScene();
    }
}
