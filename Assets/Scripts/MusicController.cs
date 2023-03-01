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
    private float stemVol;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stemVol = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
       if (stemVol < 0.0f)
       {
            stemVol = 0.0f;
       }
       else if (stemVol > 1.0f)
       {
            stemVol = 1.0f;
       }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "pellet") 
        {
            audioSource.clip = mus1;
            audioSource.Play();
            audioSource.volume = stemVol;
            //stemVol + 0.1f;
            Debug.Log("trigger hit!");
        }

        if (collision.tag == "Player") 
        {
            audioSource.clip = mus2;
            audioSource.Play();
            audioSource.volume = stemVol;
            //stemVol + 0.1f;

            Debug.Log("player trigger");
        }
    }
}
