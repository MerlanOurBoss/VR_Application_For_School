using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip3 : MonoBehaviour
{
    public buttonPushConnect buttonPushConnect;
    public GameObject tip3;
    public GameObject minigame;

    void Update()
    {
        if (buttonPushConnect.isRightRtC)
        {
            tip3.SetActive(true);
            minigame.SetActive(true);
        }
        else
        {
            tip3.SetActive(false);
            minigame.SetActive(false);
        }
    }

    public void IsOFF()
    {
        buttonPushConnect.isRightRtC = false;
    }
}
