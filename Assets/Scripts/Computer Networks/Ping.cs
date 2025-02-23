using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Random = System.Random;
public class Ping : MonoBehaviour
{
    public IPAddressGame iPAddressGame;
    public TextMeshProUGUI text;
    public TextMeshProUGUI result;

    private string randomItem;
    public void ShowIP()
    {
        result.text = null;
        Random random = new();
        int index = random.Next(iPAddressGame.allIPs.Count);
        Debug.Log(iPAddressGame.allIPs.Count);
        randomItem = iPAddressGame.allIPs[index];

        text.text = randomItem;
    }

    public void ShowResult()
    {
        result.text = "Ping " + randomItem + " (" + randomItem + ") " + " 56(84) bytes of data. \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=1  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=2  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=3  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=4  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=5  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms \n" +
            "64 bytes from " + randomItem + ":  " + "icmp_seq=6  ttl= 64 time=" + new Random().Next(1, 10) + "." + new Random().Next(1, 100) + " ms";
    }
}
