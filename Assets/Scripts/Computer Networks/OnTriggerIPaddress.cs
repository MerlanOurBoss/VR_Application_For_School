using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnTriggerIPaddress : MonoBehaviour
{
    public IPAddressGame ipaddressGame;
    private GameObject _player;
    public GameObject _miniGame;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _miniGame.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _miniGame.SetActive(false);
    }
}
