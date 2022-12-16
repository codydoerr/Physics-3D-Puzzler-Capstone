using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakbleWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (
            GetComponent<Rigidbody>().isKinematic != false && 
            collision.gameObject.GetComponent<Rigidbody>() != null && 
            Mathf.Abs(collision.gameObject.GetComponent<Rigidbody>().velocity.z) > 5
            )
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
