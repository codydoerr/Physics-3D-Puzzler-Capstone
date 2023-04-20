using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TreeOneShotScript : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] AudioMixerGroup mixerGroup;
    AudioSource aS;
    int currentClipIndex = 0;
    int[] clips = {1, 2, 3}; // integer values to represent the sounds

    void Start()
    {
        aS = GetComponent<AudioSource>();
        aS.outputAudioMixerGroup = mixerGroup;
        PlayNextClip();
        if (destroyTime > 0) {
            Destroy(gameObject, destroyTime);
        } else {
            Destroy(gameObject, aS.clip.length);
        }
    }

    void PlayNextClip() {
        if (currentClipIndex >= clips.Length) {
            return;
        }
        int clipToPlay = clips[currentClipIndex];
        currentClipIndex++;

       
        if (clipToPlay == 1) {
            aS.clip = Resources.Load<AudioClip>("Sound1");
        } else if (clipToPlay == 2) {
            aS.clip = Resources.Load<AudioClip>("Sound2");
        } else if (clipToPlay == 3) {
            aS.clip = Resources.Load<AudioClip>("Sound3");
        }
        aS.Play();
    }

    void OnDestroy()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayNextClip();
    }
}
