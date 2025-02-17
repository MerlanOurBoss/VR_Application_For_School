using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NavigationArrow : MonoBehaviour
{
    public IPAddressGame ipaddressGame;
    public IPv4Address[] pv4Addresses;
    void Update()
    {
        string targetIP = ipaddressGame.targetIP;

        for (int i= 0; i < pv4Addresses.Length; i++)
        {
            if (pv4Addresses[i].textMeshPro.text == targetIP)
            {
                Transform targetTransform = pv4Addresses[i].transform;
                Vector3 relativeTarget = transform.parent.InverseTransformPoint(targetTransform.position);
                Debug.Log("1");
                float needleRotation = Mathf.Atan2(relativeTarget.x, relativeTarget.z) * Mathf.Rad2Deg;

                transform.localRotation = Quaternion.Euler(needleRotation, -90, 0);
            }
        }
    }
}
