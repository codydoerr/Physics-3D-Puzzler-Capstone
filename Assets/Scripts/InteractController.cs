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
    public GameObject unlockableDoor;
    public Animator animator;
    private bool hasKey;
    private bool insideBox;
    private bool insideDoorBox;
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

        if (Input.GetKeyDown(KeyCode.E) && hasKey && insideDoorBox)
        {
            print("Player opens door");
            animator.Play("Door Open Animation");
            interactText.enabled = false;
            unlockableDoor.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.gameObject == KeyToDoor)
        {
            insideBox = true;
            interactText.enabled = true;
        }
        if (other.gameObject == unlockableDoor && hasKey == true)
        { 
            print("in door bounding box");
            insideDoorBox = true;
            interactText.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == KeyToDoor)
        {
            insideBox = false;
            interactText.enabled = false;
        }
        if (other.gameObject == unlockableDoor && hasKey == true)
        {
            print("left door bounding box");
            insideDoorBox = false;
            interactText.enabled = false;
        }

    }
}
