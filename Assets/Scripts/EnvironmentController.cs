using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

public class Note
{
    string content;
    string name;

    public Note(string name,string content) {
        this.name = name;
        this.content = content;
    }
}
public class EnvironmentController : MonoBehaviour
{
    public enum EnvironmentType {Door,Button,Windows,Pickups,Keypads,Elevator};
    [SerializeField] EnvironmentType eT;
    public TextMeshProUGUI InteractText;
    Animator anim;
    public Animator animator;
    public AnimationClip clip;
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
        if (connectedObject!=null)
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            anim.Play("BigRedButtonHalfPress");
            animator.Play(clip.name);
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
            if (connectedObject.name == "Elevator")
            {
                animator.Play(clip.name);
            }
            
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
        if (eT == EnvironmentType.Elevator)
        {

        }
        if (eT == EnvironmentType.Keypads)
        {

        }
        if (eT == EnvironmentType.Pickups)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddNote(this.gameObject);
            Destroy(gameObject);
        }
        if (eT == EnvironmentType.Windows)
        {

        }
    }
}
