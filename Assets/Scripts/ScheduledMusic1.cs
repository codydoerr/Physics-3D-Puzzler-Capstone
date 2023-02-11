using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledMusic1 : MonoBehaviour
{
    public float bpm = 94.00f;
    public int numBeatsPerSegment = 8;
    public AudioClip[] clips = new AudioClip[2];
    public AudioClip[] specials = new AudioClip[1];

    private double nextEventTime;
    private int flip = 0;
    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("Player");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>();
        }
        nextEventTime = AudioSettings.dspTime + 2.0f;
        running = true;
       
    }
    void Update()
    {
        
        if (!running)
        {
            return;
        }
        double time = AudioSettings.dspTime;
        //Debug.Log(time + " " + nextEventTime);
        if (time + 1.0f > nextEventTime)
        {
            // We are now approx. 1 second before the time at which the sound should play,
            // so we will schedule it now in order for the system to have enough time
            // to prepare the playback at the specified time. This may involve opening
            // buffering a streamed file and should therefore take any worst-case delay into account.
            //
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    audioSources[flip].clip = clips[flip];
            //    Debug.Log("normal");
                //
            //}
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    audioSources[flip].clip = specials[0];
            //    Debug.Log("special");
            //}
            audioSources[flip].clip = clips[flip];
            audioSources[flip].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled source " + flip + " to start at time " + nextEventTime);
            // Place the next event 16 beats from here at a rate of 140 beats per minute
            nextEventTime += 60.0f / bpm * numBeatsPerSegment;
            // Flip between two audio sources so that the loading process of one does not interfere with the one that's playing out
            flip = 1 - flip;
        }
    }
}
