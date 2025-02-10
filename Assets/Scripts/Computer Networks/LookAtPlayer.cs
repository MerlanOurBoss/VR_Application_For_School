using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerCamera;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        if (playerObject != null)
        {
            playerCamera = playerObject.transform;
        }
    }
    void Update()
    {
        if (playerCamera != null)
        {
            transform.LookAt(playerCamera);

            transform.Rotate(0, 180, 0);
        }
    }
}
