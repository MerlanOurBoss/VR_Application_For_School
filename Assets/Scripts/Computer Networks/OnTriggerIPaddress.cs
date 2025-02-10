using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnTriggerIPaddress : MonoBehaviour
{
    public GameObject ip;
    private IPAddressGame ipaddressGame;
    private GameObject _player;
    public GameObject _miniGame;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
        ipaddressGame = FindObjectOfType<IPAddressGame>();
        Debug.Log(ipaddressGame.name);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            ip.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            ipaddressGame.CheckIPAddress(ip.GetComponentInChildren<TextMeshProUGUI>().text.ToString());
            Cursor.lockState = CursorLockMode.None;
            _miniGame.SetActive(true);
            _player.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ip.SetActive(false);
    }
}
