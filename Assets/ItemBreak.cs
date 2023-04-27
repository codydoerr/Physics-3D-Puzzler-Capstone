using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBreak : MonoBehaviour
{
    [SerializeField] bool isTree;
    [SerializeField] bool isWindow;
    [SerializeField] int breakLimit;
    [SerializeField] GameObject[] breakingSounds;
    private void OnCollisionEnter(Collision collision)
    {

        AmmoType ammoType = null;
        if (collision.gameObject.GetComponent<AmmoType>())
        {
            ammoType = collision.gameObject.GetComponent<AmmoType>();
        }

        if(ammoType != null && ammoType.GetAmmoType() == AmmoType.Ammo.Normal)
        {
            if (breakLimit > 0)
            {
                Instantiate(breakingSounds[breakLimit - 1]);
                breakLimit--;
            }
            if(breakLimit == 0)
            {
                if (isTree)
                {
                    //GetComponent<ConfigurableJoint>().angularXMotion = ConfigurableJointMotion.Free;
                    GetComponent<ConfigurableJoint>().angularYMotion = ConfigurableJointMotion.Limited;
                    GetComponent<ConfigurableJoint>().angularXMotion = ConfigurableJointMotion.Limited;
                }
                else if (isWindow) {
                    Destroy(gameObject);
                }
                else
                {
                    GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Free;
                    GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Free;
                    GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Free;
                }
            }
        }
        else if(collision.gameObject.GetComponent<ItemBreak>() && collision.gameObject.GetComponent<ItemBreak>().IsTree())
        {
            if (isWindow)
            {
                collision.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
                Destroy(gameObject);

            }
        }
    }
    public bool IsTree()
    {
        return isTree;
    }
    

}
