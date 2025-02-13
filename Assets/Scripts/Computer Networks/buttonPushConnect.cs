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
    private GameObject textMeshPro;

    private void Start()
    {
        textMeshPro = GameObject.FindGameObjectWithTag("TextCamera");
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
        TextMeshPro textMain = textMeshPro.GetComponent<TextMeshPro>();
        textMain.text = "";
        if (str == "Computer->Commutator")
        {
            if (isStraight)
            {
                textMain.text = "Дұрыс қосылды";
                anim.Play("InsertCabel");
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
            }
            else
            {
                textMain.text = "Қате қосылым";
            }
        }
    }
}
