using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPad : MonoBehaviour
{
    string sequence;
    [SerializeField]string answer;
    bool inRange;
    [SerializeField]GameObject clickPrefab;
    [SerializeField] GameObject wrongPrefab;
    [SerializeField] GameObject rightPrefab;
    [SerializeField] GameObject door;
    bool doorOpen = false;

    public void keyPress(string key)
    {
        Instantiate(clickPrefab, transform.position, Quaternion.identity);
        sequence += key;
        if (sequence.Length == answer.Length && sequence == answer && doorOpen == false)
        {
            Instantiate(rightPrefab, transform.position, Quaternion.identity);
            door.transform.Rotate(0.0f, 100.0f, 0.0f, Space.Self);
            Debug.Log("Open Door");
            doorOpen = true;
        } else if (sequence.Length == answer.Length)
        {
            Instantiate(wrongPrefab, transform.position, Quaternion.identity);
            sequence = "";
            Debug.Log("reset sequence");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ShootingController>() != null)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ShootingController>() != null)
        {
            inRange = false;
        }
        
    }

    private void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        if (inRange && Input.GetKeyDown(KeyCode.E) && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("button press");
            if (hit.collider.gameObject.GetComponent<keyNum>() != null)
            {
                Debug.Log(hit.collider.gameObject.GetComponent<keyNum>().getKeyNo());
                keyPress(hit.collider.gameObject.GetComponent<keyNum>().getKeyNo());
            }
        }
    }
}
