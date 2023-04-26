using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject currentAmmo;
    [SerializeField] GameObject rotator;
    [SerializeField] GameObject loadPoint;
    [SerializeField] GameObject[] inventoryAmmo;
    [SerializeField] GameObject gM;
    [SerializeField] GameObject tabletPrefab;

    [SerializeField] new Camera camera;

    [SerializeField] float startingZoom;
    [SerializeField] float aimZoomDelta;
    bool ammoLoaded;
    GameObject placedCamera;
    GameObject loadedAmmo;
    [SerializeField] float power;
    [SerializeField] float speedH = 2.0f;
    [SerializeField] float speedV = 2.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;

    public GameObject slingShotPrefab;
    private GameObject ssSound;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        bool isCamera = currentAmmo.GetComponent<AmmoType>().GetAmmoType() == AmmoType.Ammo.Camera;
        if (Input.GetKeyDown(KeyCode.Q) && !IsTabletActive())
        {
            tabletPrefab.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && IsTabletActive())
        {
            tabletPrefab.SetActive(false);
        }
        if (IsTabletActive() && placedCamera)
        {
            placedCamera.transform.Rotate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0) && !gM.GetComponent<GameManager>().isGamePaused())
        {
            //change this to only destroy camera or gravity
            //other will destroy after 3 seconds
            if (IsTabletActive())
            {
                tabletPrefab.SetActive(false);
            }
            if (!ammoLoaded && isCamera)
            {
                Destroy(placedCamera);
                placedCamera = Instantiate(currentAmmo, loadPoint.transform.position, Quaternion.Euler(rotator.transform.rotation.eulerAngles.x, rotator.transform.rotation.eulerAngles.y, 0));
                ammoLoaded = true;
            }
            else if (!ammoLoaded)
            {
                loadedAmmo = Instantiate(currentAmmo, loadPoint.transform.position, Quaternion.Euler(rotator.transform.rotation.eulerAngles.x, rotator.transform.rotation.eulerAngles.y, 0));
                ammoLoaded = true;
            }
        }
        else if (Input.GetMouseButton(0) && ammoLoaded)
        {
            camera.transform.localPosition = new Vector3(0, 0, aimZoomDelta);
            if (placedCamera)
            {
                placedCamera.transform.position = loadPoint.transform.position;
                placedCamera.transform.rotation = loadPoint.transform.rotation;
            }
            else
            {
                loadedAmmo.transform.position = loadPoint.transform.position;
                loadedAmmo.transform.rotation = loadPoint.transform.rotation;
            }
        }
        else
        {
            camera.transform.localPosition = new Vector3(0, 0, startingZoom);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentAmmo.GetComponent<AmmoType>().GetAmmoType() == AmmoType.Ammo.Camera)
            {
                ammoLoaded = false;
                placedCamera.GetComponent<AmmoType>().FireAmmo(power);
                StartCoroutine(WaitForPlacedCamera());
            } else
            {
                ammoLoaded = false;
                loadedAmmo.GetComponent<AmmoType>().FireAmmo(power);
            }
            loadedAmmo = null;
            ssSound = Instantiate(slingShotPrefab, transform.position, Quaternion.identity);
            ssSound.GetComponent<AudioSource>().pitch = (Random.Range(1.0f, 1.2f));

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchAmmo(0);
            Debug.Log("Armed normal_stone");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchAmmo(1);
            Debug.Log("Armed camera");
        }
    }
    private IEnumerator WaitForPlacedCamera()
    {

        yield return new WaitUntil(() => placedCamera.GetComponent<Rigidbody>().velocity == Vector3.zero);
        Debug.Log("setactive");
        tabletPrefab.SetActive(true);
        tabletPrefab.GetComponent<TabletController>().SetCamera(placedCamera);
        placedCamera = null;
        Debug.Log("camset");
    }

    public bool IsTabletActive()
    {
        return tabletPrefab.activeInHierarchy;
    }
    public bool IsPlayerCocked()
    {
        return ammoLoaded;
    }
    private void SwitchAmmo(int type)
    {
        currentAmmo = inventoryAmmo[type];
    }
}
