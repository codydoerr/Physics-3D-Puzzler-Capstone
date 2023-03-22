using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemController : MonoBehaviour
{
    public GameObject musicElement;
    public AudioSource audioSource;
    public float stemVol;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        stemVol = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = stemVol;
    }

    public void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "pellet") 
        {
            stemVol = Mathf.Lerp(stemVol, 1, 0.25f * Time.deltaTime);
            Debug.Log(stemVol);
            Debug.Log("trigger hit!");
        }

        if (collision.tag == "Player") 
        {
            stemVol = Mathf.Lerp(stemVol, 1, 0.5f * Time.deltaTime);
            Debug.Log(stemVol);
            Debug.Log("player trigger");
        }
    }
}