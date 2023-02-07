using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip mus1;
    [SerializeField] AudioClip mus2;
    [SerializeField] AudioClip mus3;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = mus1; 
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
