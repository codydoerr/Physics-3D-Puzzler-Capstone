using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//https://answers.unity.com/questions/1917193/is-there-a-way-to-make-a-press-e-to-interact-when.html

public class InteractController : MonoBehaviour
{
    public GameObject KeyToDoor;
    public bool hasKey;
    public bool insideBox;
    public TextMeshProUGUI interactText;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        insideBox = false;
        interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && insideBox)
        {
            print("Player has Key");
            KeyToDoor.SetActive(false);
            hasKey = true;
            interactText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        insideBox = true;
        interactText.enabled = true;
    }
    void OnTriggerExit(Collider other)
    {
        insideBox = false;
        interactText.enabled = false;
    }
}
