using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float upDownValue = Input.GetAxis("Vertical");
        float leftRightValue = Input.GetAxis("Horizontal");

        camera.transform.Rotate(new Vector3(upDownValue, -leftRightValue ,0  ), Space.Self);
    }
    public void SetCamera(GameObject newCamera)
    {
        camera = newCamera;
    }
}
