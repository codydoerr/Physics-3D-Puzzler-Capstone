using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoType : MonoBehaviour
{
    private enum Ammo {Normal,Heavy,Gravity};
    [SerializeField] Ammo currentAmmo;
    bool effect;
    [SerializeField] GameObject effectSpawn;
    float power = 0;
    public void FireAmmo(float power)
    {
        GetComponent<Rigidbody>().useGravity = true;

        if (currentAmmo == Ammo.Heavy)
        {
            this.power = power * 3;
        }
        else
        {
            this.power = power;
        }
        Launch();
    }
    private void Launch()
    {
        if (currentAmmo == Ammo.Normal)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
        }
        else if (currentAmmo == Ammo.Heavy)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
        }
        else if (currentAmmo == Ammo.Gravity)
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
        }
    }
}
