using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject crosshair;

    [SerializeField] Sprite basicCross;

    [SerializeField] Sprite cameraCross;

    public void SwapCrosshair()
    {
        if (crosshair.GetComponent<Image>().sprite == basicCross) { 

            crosshair.GetComponent<Image>().sprite = cameraCross;
        }
        else
        {
            crosshair.GetComponent<Image>().sprite = basicCross;
        }
    }
}
