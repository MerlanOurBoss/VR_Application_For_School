using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttonPushConnect : MonoBehaviour
{
    public bool isCrossover = false;
    public bool isStraight = false;
    public Animator anim;
    public GameObject textMeshPro;
    public TextMeshProUGUI textMain;
    public IPAddressGame iPAddressGame;
    public bool isRightRtC = false;

    public Toggle routerToInternet;
    public Toggle commutatorToRouter;

    public WaitForTouch waitForTouch;
    public Tip3 tip3;
    public GameObject computerThings;
    private void Start()
    {
        textMeshPro = GameObject.FindGameObjectWithTag("TextCamera");
        textMain = textMeshPro.GetComponent<TextMeshProUGUI>();
    }
    public void MakeCrossover()
    {
        Debug.Log("Crossover");
        isCrossover = true;
        isStraight = false;
    }

    public void MakeStraight()
    {
        Debug.Log("Straight");
        isCrossover = false;
        isStraight = true;
    }

    public void Connect(string str)
    {
        
        //textMain.text = "";
        if (str == "Computer->Commutator")
        {
            if (isStraight)
            {
                textMain.text = "Дұрыс қосылды";
                anim.Play("InsertCabel");
                StartCoroutine(EnableRouterAfterAnimation3()); 
                if (iPAddressGame != null)
                {
                    iPAddressGame.countComputer++;
                    iPAddressGame.NextTargetIP();
                    iPAddressGame = null;
                }
            }
            else
            {
                textMain.text = "Қате қосылым";
            }
        }
        else if (str == "Router->Internet")
        {
            if (isStraight)
            {
                textMain.text = "Дұрыс қосылды";
                anim.Play("InsertCabel");
                isRightRtC = true;
                StartCoroutine(EnableRouterAfterAnimation());
                if (routerToInternet != null)
                {
                    routerToInternet.isOn = true;
                }
                
            }
            else
            {
                textMain.text = "Қате қосылым";
            }
        }
        else if (str == "Router->Commutator")
        {
            if (isStraight)
            {
                textMain.text = "Дұрыс қосылды";
                anim.Play("InsertCabel");
                StartCoroutine(EnableRouterAfterAnimation2());
                if (iPAddressGame != null)
                {
                    iPAddressGame.isStarted = true;
                }
                if (commutatorToRouter != null)
                {
                    commutatorToRouter.isOn = true;
                }
            }
            else
            {
                textMain.text = "Қате қосылым";
            }
        }
    }

    private IEnumerator EnableRouterAfterAnimation()
    {
        // Ожидание завершения анимации
        yield return new WaitForSeconds(4f);

        if (waitForTouch != null)
        {
            waitForTouch.isTouched = false;
        }
    }

    private IEnumerator EnableRouterAfterAnimation2()
    {
        // Ожидание завершения анимации
        yield return new WaitForSeconds(4f);

        if (tip3 != null)
        {
            tip3.IsOFF();
        }
    }

    private IEnumerator EnableRouterAfterAnimation3()
    {
        // Ожидание завершения анимации
        yield return new WaitForSeconds(4f);

        if (computerThings != null)
        {
            computerThings.SetActive(false);
        }
        
    }
}
