using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    bool inRange;
    GameObject loadPoint;
    bool pickedUp;
    private void Start()
    {
        inRange = false;
        pickedUp = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ShootingController>() != null)
        {
            inRange = true;
            loadPoint = other.GetComponent<ShootingController>().GetLoadPoint();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ShootingController>() != null)
        {
            inRange = false;
            loadPoint = null;
        }
    }
    private void Update()
    {
        if (pickedUp)
        {
            GetComponent<Rigidbody>().MovePosition(loadPoint.transform.position + Camera.main.transform.forward - Camera.main.transform.up / 2);
            transform.rotation = loadPoint.transform.rotation;
        }
    }
    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;

        if (inRange && Input.GetKey(KeyCode.E) && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("reaching out");
            if (hit.collider.gameObject.GetComponent<PickupObjects>() != null)
            {
                pickedUp = true;
                StartCoroutine(DisableGravTillDropped());
            }
        }else if(!inRange || Input.GetKeyUp(KeyCode.E))
        {
            pickedUp = false;
        }

    }
    
    IEnumerator DisableGravTillDropped()
    {
        GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
        GetComponent<Rigidbody>().useGravity = true;
    }
}
