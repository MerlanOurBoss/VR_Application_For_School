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

    public bool isCorrect = false;
    public AIHelper AIHelper;

    public GameObject CrossoverRed;
    public GameObject StraightRed;
    public GameObject StraightGreen;
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
        if (str == "Computer->Commutator")
        {
            if (isStraight)
            {
                AIHelper.OnCorrectAction();
                isCorrect = true;
                anim.Play("InsertCabel");
                StartCoroutine(EnableRouterAfterAnimation3());

                CrossoverRed.SetActive(false);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(true);

                if (iPAddressGame != null)
                {
                    iPAddressGame.countComputer++;
                    iPAddressGame.NextTargetIP();
                    iPAddressGame = null;
                }
            }
            else
            {
                AIHelper.OnIncorrectAction();

                CrossoverRed.SetActive(true);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(false);

                isCorrect = false;
            }
        }
        else if (str == "Router->Internet")
        {
            if (isStraight)
            {
                AIHelper.OnCorrectAction();
                isCorrect = true;
                anim.Play("InsertCabel");
                isRightRtC = true;
                StartCoroutine(EnableRouterAfterAnimation());

                CrossoverRed.SetActive(false);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(true);

                if (routerToInternet != null)
                {
                    routerToInternet.isOn = true;
                }
            }
            else
            {
                AIHelper.OnIncorrectAction();

                CrossoverRed.SetActive(true);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(false);

                isCorrect = false;
            }
        }
        else if (str == "Router->Commutator")
        {
            if (isStraight)
            {
                AIHelper.OnCorrectAction();
                isCorrect = true;
                anim.Play("InsertCabel");
                StartCoroutine(EnableRouterAfterAnimation2());

                CrossoverRed.SetActive(false);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(true);

                if (iPAddressGame != null)
                {
                    iPAddressGame.isStarted = true;
                    iPAddressGame = null;
                }
                if (commutatorToRouter != null)
                {
                    commutatorToRouter.isOn = true;
                }
            }
            else
            {
                AIHelper.OnIncorrectAction();

                CrossoverRed.SetActive(true);
                StraightRed.SetActive(false);
                StraightGreen.SetActive(false);

                isCorrect = false;
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
