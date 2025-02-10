using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMiniGame : MonoBehaviour
{
    public GameObject _miniGame;
    public IPAddressGame pv4Address;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            pv4Address.isStarted = true;
            _miniGame.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
