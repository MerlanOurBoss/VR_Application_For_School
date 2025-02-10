using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public GameObject parent;
    public GameObject shpereTip;
    public GameObject shpereTipStart;
    private bool isPickable = false;
    private void OnTriggerEnter(Collider other)
    {
        isPickable = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isPickable && Input.GetKey(KeyCode.E))
        {
            parent.SetActive(false);
            shpereTip.SetActive(true);
            shpereTipStart.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPickable = false;
    }
}
