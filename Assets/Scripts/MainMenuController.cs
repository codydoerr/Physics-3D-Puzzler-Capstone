using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] VideoClip idleClip;
    [SerializeField] VideoClip animationClip;

    [SerializeField] VideoPlayer vP;

    [SerializeField] SceneManager sM;

    [SerializeField] GameObject transition;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void TransitionScene()
    {
        transition.GetComponent<Animator>().SetTrigger("FadeOut");
    }
    public void StartVideo()
    {
        vP.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
