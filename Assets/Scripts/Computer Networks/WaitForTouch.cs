using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTouch : MonoBehaviour
{
    public GameObject canvas;
    public GameObject RJ45HighLigth;

    public bool isTouched;

    private void Update()
    {
        if (isTouched)
        {
            canvas.SetActive(true);
            RJ45HighLigth.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
            RJ45HighLigth.SetActive(false);
        }
    }

    public void isOFF()
    {
        isTouched = false;
    }
}
