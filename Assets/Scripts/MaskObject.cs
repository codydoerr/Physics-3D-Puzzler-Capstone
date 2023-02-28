using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    public GameObject[] maskObj;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject maskObj in maskObj)
        {
            maskObj.GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
