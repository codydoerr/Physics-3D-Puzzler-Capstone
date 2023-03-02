using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoType : MonoBehaviour
{
    public enum Ammo {Normal,Gravity,Camera};
    [SerializeField] Ammo currentAmmo;
    bool effect;
    [SerializeField] GameObject effectSpawn;
    [SerializeField] RenderTexture cameraRender;
    float power = 0;
    public void FireAmmo(float power)
    {
        GetComponent<Rigidbody>().useGravity = true;
        this.power = power;
        Launch();
    }
    public Ammo GetType()
    {
        return currentAmmo;
    }
    private void Launch()
    {
        if (currentAmmo == Ammo.Normal)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
        }
        else if (currentAmmo == Ammo.Gravity)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
        }
        else if (currentAmmo == Ammo.Camera)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (currentAmmo == Ammo.Gravity)
        {
            effectSpawn.GetComponent<EffectsController>().parent = this.gameObject;
            effectSpawn.SetActive(true);
            effectSpawn.transform.parent = null;
        }else if(currentAmmo == Ammo.Camera)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            effectSpawn.SetActive(true);
            effectSpawn.GetComponent<Camera>().targetTexture = cameraRender;
        }
    }
}
