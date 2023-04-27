using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject crosshair;

    [SerializeField] Sprite basicCross;

    [SerializeField] Sprite cameraCross;
    [SerializeField] GameObject[] notes;

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
    public void ActivateNote(int noteNum)
    {

        Debug.Log("note num" + noteNum);
        Debug.Log("the note" + notes[noteNum - 1]);
        notes[noteNum-1].SetActive(true);
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (GameObject item in notes)
            {
                item.SetActive(false);
            }
        }
    }
}
