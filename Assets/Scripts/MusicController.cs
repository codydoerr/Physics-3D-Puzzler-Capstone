using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip mus1;
    [SerializeField] AudioClip mus2;
    [SerializeField] AudioClip mus3;
    [SerializeField] AudioClip mus4;
    public GameObject musicElement;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //AudioClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "pellet") 
        {
            audioSource.clip = mus1;
            audioSource.Play();
            Debug.Log("trigger hit!");
        }

        if (collision.tag == "Player") 
        {
            audioSource.clip = mus2;
            audioSource.Play();
            Debug.Log("player trigger");
        }
    }
}
