using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoType : MonoBehaviour
{
    private enum Ammo {Normal,Heavy };
    [SerializeField] Ammo currentAmmo;
    float power = 0;
    public void FireAmmo(float power)
    {
        GetComponent<Rigidbody>().useGravity = true;
        if (currentAmmo == Ammo.Normal)
        {
            this.power = power;

        }
        else if (currentAmmo == Ammo.Heavy)
        {
            this.power = power * 3;
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
    }
}
