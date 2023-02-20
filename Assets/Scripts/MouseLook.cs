using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform camera;
    [SerializeField] Transform bodyCenter;
    float xRotation = 0f;
    GameObject lastEnvironmentEnabled;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetMouseSens(float newSens)
    {
        mouseSensitivity = newSens;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 1000f * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 1000f * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private void FixedUpdate()
    {
        Vector3 fwd = bodyCenter.transform.TransformDirection(bodyCenter.transform.forward);
        RaycastHit hit;
        if (!Physics.Raycast(camera.transform.position, fwd, out hit, 5f))
        {
            return;
        }
        else if (Physics.Raycast(camera.transform.position, fwd, out hit, 5f) && (hit.collider.gameObject.GetComponent<EnvironmentController>()!=null|| hit.collider.gameObject.GetComponentInParent<EnvironmentController>() != null))
        {
            lastEnvironmentEnabled = hit.collider.gameObject;

            hit.collider.gameObject.GetComponent<EnvironmentController>().MakeUsable();
        }
        Debug.DrawRay(camera.transform.position, fwd,Color.green,5f);
    }
}
