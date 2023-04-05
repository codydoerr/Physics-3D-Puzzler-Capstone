using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://answers.unity.com/questions/1917193/is-there-a-way-to-make-a-press-e-to-interact-when.html

public class InteractController : MonoBehaviour
{
    public GameObject KeyToDoor;
    public bool hasKey;
    public bool inBox;
    public Text interactText;
    float raycastDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // This creates a 'ray' at the Main Camera's Centre Point essentially the centre of the users Screen
        //RaycastHit hit; //This creates a Hit which is used to callback the object that was hit by the Raycast
        if (Input.GetKeyDown(KeyCode.E) && inBox)
        {
            print("Player has Key");
            KeyToDoor.SetActive(false);
            hasKey = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inBox = true;
    }
}
