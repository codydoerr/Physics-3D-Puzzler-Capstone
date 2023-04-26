using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OneShotController : MonoBehaviour
{
    [SerializeField] float destroyTime;
    AudioClip clip;
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = this.GetComponent<AudioSource>();
        clip = aS.clip;
        if (destroyTime > 0) {
            Destroy(this, destroyTime);
        }
        else
        {
            Destroy(this, clip.length);
        }
    }
}
