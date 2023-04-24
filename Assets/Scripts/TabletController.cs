using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float upDownValue = Input.GetAxis("Vertical");
        float leftRightValue = Input.GetAxis("Horizontal");
        float spinValue = Input.mouseScrollDelta.y;
        Vector3 rotation = new Vector3(upDownValue, -leftRightValue, spinValue*3)*rotationSpeed;
        camera.transform.Rotate(rotation, Space.Self);
    }
    public void SetCamera(GameObject newCamera)
    {
        camera = newCamera;
    }
}
