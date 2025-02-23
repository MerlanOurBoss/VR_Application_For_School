using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vlan : MonoBehaviour
{
    public int vlanNumber = 0;
    public TextMeshProUGUI vlanText;

    private void Update()
    {
        vlanText.text = "Vlan - " + vlanNumber;
    }

    public void AddCount()
    {
        vlanNumber++;
    }
}
