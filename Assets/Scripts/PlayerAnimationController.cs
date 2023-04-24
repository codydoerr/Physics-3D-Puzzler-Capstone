using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator pAnim;
    public void StartWalking()
    {
        pAnim.SetBool("Walking", true);
    }
    public void EndWalking()
    {
        pAnim.SetBool("Walking", false);
    }
    public void TriggerJump()
    {
        pAnim.SetTrigger("Jump");
    }

}
