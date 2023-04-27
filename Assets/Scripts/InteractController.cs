using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//https://answers.unity.com/questions/1917193/is-there-a-way-to-make-a-press-e-to-interact-when.html

public class InteractController : MonoBehaviour
{
    [SerializeField] GameObject CameraPickup;
    public GameObject KeyToDoor;
    public GameObject unlockableDoor;
    [SerializeField] GameObject Elevator;
    [SerializeField] GameObject Vent;
    [SerializeField] GameObject Bolt1;
    [SerializeField] GameObject Bolt2;
    [SerializeField] GameObject Bolt3;
    [SerializeField] GameObject Bolt4;
    public Animator doorAnimator;
    [SerializeField] Animator elevatorAnimator;
    private bool hasKey;
    private bool insideBox;
    private bool insideDoorBox;
    bool isElevator;
    bool isVent;
    bool isCamera;
    public TextMeshProUGUI interactText;
    public Vector3 newPosition;
    public CharacterController controller;

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
        if (Input.GetKeyDown(KeyCode.E) && isCamera)
        {
            CameraPickup.SetActive(false);
            interactText.enabled = false;
        }

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

        if (Input.GetKeyDown(KeyCode.E) && isVent && Bolt1 == null && Bolt2 == null && Bolt3 == null && Bolt4 == null)
        {
            print(gameObject);
            controller.enabled = false; // disable controller temporarily
            transform.position = newPosition; // set new position
            controller.enabled = true; // re-enable controller
            interactText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.gameObject == CameraPickup)
        {
            interactText.enabled = true;
            isCamera = true;
        }
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
        if (other.gameObject == Vent && Bolt1 == null && Bolt2 == null && Bolt3 == null && Bolt4 == null)
        {
            interactText.enabled = true;
            isVent = true;
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
        if (other.gameObject == CameraPickup)
        {
            interactText.enabled = false;
            isCamera = false;
        }
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
        if (other.gameObject == Vent && Bolt1 == null && Bolt2 == null && Bolt3 == null && Bolt4 == null    )
        {
            interactText.enabled = false;
            isVent = false;
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
