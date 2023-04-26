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
    [SerializeField] GameObject Elevator;
    public Animator doorAnimator;
    [SerializeField] Animator elevatorAnimator;
    private bool hasKey;
    private bool insideBox;
    private bool insideDoorBox;
    bool isElevator;
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
            doorAnimator.Play("Door Open Animation");
            interactText.enabled = false;
            unlockableDoor.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && isElevator)
        {
            elevatorAnimator.Play("Close Elevator 0");
            interactText.enabled = false;
            Elevator.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.gameObject == KeyToDoor)
        {
            interactText.enabled = true;
            insideBox = true;
        }
        if (other.gameObject == Elevator)
        {
            interactText.enabled = true;
            isElevator = true;
        }
        if (other.gameObject == unlockableDoor && hasKey == true)
        { 
            print("in door bounding box");
            insideDoorBox = true;
            interactText.enabled = true;
        }
        if (other.gameObject.GetComponent<EnvironmentController>() &&
            other.gameObject.GetComponent<EnvironmentController>().GetEnvironmentType() == EnvironmentController.EnvironmentType.Pickups
            ){
            interactText.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == KeyToDoor)
        {
            interactText.enabled = false;
            insideBox = false;
        }
        if (other.gameObject == Elevator)
        {
            interactText.enabled = false;
            isElevator = false;
        }
        if (other.gameObject == unlockableDoor && hasKey == true)
        {
            print("left door bounding box");
            insideDoorBox = false;
            interactText.enabled = false;
        }
        if (other.gameObject.GetComponent<EnvironmentController>() &&
        other.gameObject.GetComponent<EnvironmentController>().GetEnvironmentType() == EnvironmentController.EnvironmentType.Pickups
        ){
            interactText.enabled = false;
        }

    }
}
