using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class EnvironmentController : MonoBehaviour
{
    public enum EnvironmentType {Door,Button,Windows,Pickups,Keypads};
    [SerializeField] EnvironmentType eT;
    Animator anim;
    KeyCode use = KeyCode.E;
    HingeJoint[] movingAsset = new HingeJoint[2];
    [SerializeField] GameObject staticAsset;
    bool isUsable;
    // Start is called before the first frame update
    void Start()
    {
        isUsable = false;
        movingAsset = staticAsset.GetComponents<HingeJoint>();
        anim = GetComponent<Animator>();
    }
    public void MakeUsable()
    {
        isUsable = true;
    }
    public void MakeUnUsable()
    {
        isUsable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (eT == EnvironmentType.Door)
        {
            if (Input.GetKeyDown(use) && isUsable)
            {
                var motor = movingAsset[0].motor;
                motor.targetVelocity *= -1;
                foreach (HingeJoint aMotor in movingAsset)
                {
                    aMotor.motor = motor;
                }
            }
        }
        if(eT == EnvironmentType.Button)
        {
            if (Input.GetKeyDown(use) && isUsable)
            {
                anim.SetTrigger("Press");
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
