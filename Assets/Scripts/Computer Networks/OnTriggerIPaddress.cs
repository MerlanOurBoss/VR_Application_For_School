using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnTriggerIPaddress : MonoBehaviour
{
    public GameObject _miniGame;
    private void VisibleGameObject()
    {
        _miniGame.SetActive(true);
    }

    private void InvisibleGameObject()
    {
        _miniGame.SetActive(false);
    }
}
