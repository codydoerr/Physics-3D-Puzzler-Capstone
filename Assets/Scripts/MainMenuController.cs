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

    int vidState = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartVideo();
        vidState = 0;
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
        StartCoroutine(WaitForPlaying());
    }
    IEnumerator WaitForPlaying()
    {
        yield return new WaitUntil(() => vP.isPlaying);
        vidState++;
    }
    void SetNextVid()
    {
        vP.clip = idleClip;
        vP.Play();
        vP.isLooping = true;
        StartCoroutine(WaitForPlaying());
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    // Update is called once per frame
    void Update()
    {
        if(!vP.isPlaying && vidState == 1)
        {
            SetNextVid();
        }
    }
}
