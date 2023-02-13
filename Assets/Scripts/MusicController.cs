using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip mus1;
    [SerializeField] AudioClip mus2;
    [SerializeField] AudioClip mus3;
    public GameObject musicElement;
    public AudioSource audioSource;
    private int timesHit;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if (timesHit > 3) 
       {
        timesHit = 0;
       } 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "pellet") 
        {
            audioSource.clip = mus1;
            audioSource.Play();

            timesHit++;
            Debug.Log("trigger hit!");
        }
    }
}
