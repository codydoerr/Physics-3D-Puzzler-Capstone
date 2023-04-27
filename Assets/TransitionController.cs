using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    MainMenuController mmc;
    private void Start()
    {
        mmc = GameObject.Find("MainMenuCanvas").GetComponent<MainMenuController>();
    }
    public void StartVideo()
    {
        mmc.StartVideo();
    }
}
