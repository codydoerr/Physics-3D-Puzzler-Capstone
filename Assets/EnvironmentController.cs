using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvironmentController : MonoBehaviour
{
    KeyCode use = KeyCode.E;
    HingeJoint[] movingAsset = new HingeJoint[2];
    [SerializeField] GameObject staticAsset;
    bool isUsable;
    // Start is called before the first frame update
    void Start()
    {
        isUsable = false;
        movingAsset = staticAsset.GetComponents<HingeJoint>();
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
    private void LateUpdate()
    {
        MakeUnUsable();
    }
}
