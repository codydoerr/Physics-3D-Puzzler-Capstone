using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class EnvironmentController : MonoBehaviour
{
    public enum EnvironmentType {Door,Button,Windows,Pickups,Keypads,Elevator};
    [SerializeField] EnvironmentType eT;
    Animator anim;
    KeyCode use = KeyCode.E;
    HingeJoint[] movingAsset = new HingeJoint[2];
    [SerializeField] GameObject staticAsset;
    [SerializeField] GameObject connectedObject;
    bool isUsable;
    // Start is called before the first frame update
    void Start()
    {
        isUsable = false;
        if (eT == EnvironmentType.Door)
        {
            movingAsset = staticAsset.GetComponents<HingeJoint>();
        }
        anim = GetComponent<Animator>();
    }
    public void MakeUsable()
    {
        isUsable = true;
    }
    public void MakeUnUsable()
    {
        isUsable = false;
        if (connectedObject)
        {
            if (connectedObject.GetComponent<EnvironmentController>())
            {
                connectedObject.GetComponent<EnvironmentController>().MakeUnUsable();
            }
            else if (connectedObject.GetComponentInParent<EnvironmentController>())
            {
                connectedObject.GetComponentInParent<EnvironmentController>().MakeUnUsable();
            }
            else if (connectedObject.GetComponentInChildren<EnvironmentController>())
            {
                connectedObject.GetComponentInChildren<EnvironmentController>().MakeUnUsable();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(use) && isUsable)
        {
            UseObject();
        }
    }
    public void UseObject()
    {
        if (eT == EnvironmentType.Button)
        {
            if (connectedObject.GetComponent<EnvironmentController>())
            {
                connectedObject.GetComponent<EnvironmentController>().MakeUsable();
                connectedObject.GetComponent<EnvironmentController>().UseObject();
            }
            else if (connectedObject.GetComponentInParent<EnvironmentController>())
            {
                connectedObject.GetComponentInParent<EnvironmentController>().MakeUsable();
                connectedObject.GetComponentInParent<EnvironmentController>().UseObject();
            }
            else if (connectedObject.GetComponentInChildren<EnvironmentController>())
            {
                connectedObject.GetComponentInChildren<EnvironmentController>().MakeUsable();
                connectedObject.GetComponentInChildren<EnvironmentController>().UseObject();
            }
            anim.SetTrigger("Press");
        }
        if (eT == EnvironmentType.Door)
        {
                var motor = movingAsset[0].motor;
                motor.targetVelocity *= -1;
                foreach (HingeJoint aMotor in movingAsset)
                {
                    aMotor.motor = motor;
                }
           
        }
        if (eT == EnvironmentType.Keypads)
        {

        }
        if (eT == EnvironmentType.Pickups)
        {

        }
        if (eT == EnvironmentType.Windows)
        {

        }
    }
}
