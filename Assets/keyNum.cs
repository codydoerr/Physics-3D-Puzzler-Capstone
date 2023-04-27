using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyNum : MonoBehaviour
{
    string keyNo;
    private void Start()
    {
        keyNo = gameObject.name;
    }

    public string getKeyNo ()
    {
        return keyNo;
    }
}
