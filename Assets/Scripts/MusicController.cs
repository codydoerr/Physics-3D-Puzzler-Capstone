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
    public float stemVol;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        stemVol = 0.0f;
        audioSource.volume = stemVol;
        
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
            stemVol = Mathf.Lerp(0, 1, 0.25f * Time.deltaTime);
            Debug.Log(stemVol);
            Debug.Log("trigger hit!");
        }

        if (collision.tag == "Player") 
        {
            audioSource.clip = mus2;
            stemVol = Mathf.Lerp(0, 1, 0.5f * Time.deltaTime);
            Debug.Log(stemVol);
            Debug.Log("player trigger");
        }
    }
}
