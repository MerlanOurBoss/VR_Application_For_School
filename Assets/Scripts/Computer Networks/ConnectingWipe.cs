using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectingWipe : MonoBehaviour
{
    public GameObject _player;
    public Animator wipes;
    public TMP_Dropdown cableTypeDropdown; // Выпадающее меню для типа кабеля
    public TMP_Dropdown standard1Dropdown; // Выпадающее меню для первого конца кабеля
    public TMP_Dropdown standard2Dropdown; // Выпадающее меню для второго конца кабеля
    public TextMeshProUGUI feedbackText; // Текст подсказки
    public Manager man;
    public GameObject miniGame;

    public GameObject T568A;
    public GameObject T568B;
    private bool isCorrect = false;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
        man = FindObjectOfType<Manager>();
        RandomizeDropdownValues();
    }

    private void Update()
    {
        if (standard2Dropdown.options[standard2Dropdown.value].text == "T568A")
        {
            T568A.SetActive(true);
            T568B.SetActive(false);
        }
        else
        {
            T568A.SetActive(false);
            T568B.SetActive(true);
        }
    }

    public void RandomizeDropdownValues()
    {
        cableTypeDropdown.value = Random.Range(0, cableTypeDropdown.options.Count);
        standard1Dropdown.value = Random.Range(0, standard1Dropdown.options.Count);
        standard2Dropdown.value = Random.Range(0, standard2Dropdown.options.Count);
    }
    public void CheckConnection(string connectionType)
    {
        string cableType = cableTypeDropdown.options[cableTypeDropdown.value].text;
        string standard1 = standard1Dropdown.options[standard1Dropdown.value].text;
        string standard2 = standard2Dropdown.options[standard2Dropdown.value].text;

        isCorrect = false;
        feedbackText.text = "";
        Debug.Log(cableType + " " + standard1 + " " + standard2);
        switch (connectionType)
        {
            case "RouterToSwitch":
                if (cableType == "Тікелей" && standard1 == standard2)
                {
                    isCorrect = true;
                }
                else
                {
                    feedbackText.text = "Маршрутизаторды коммутаторға қосу үшін бірдей стандарттарға ие түзу кабель қажет!";
                }
                break;

            case "ComputerToSwitch":
                if (cableType == "Тікелей" && standard1 == standard2)
                {
                    isCorrect = true;
                }
                else
                {
                    feedbackText.text = "Компьютерді коммутаторға қосу үшін бірдей стандарттарға ие тікелей кабель қажет!";
                }
                break;

            case "SwitchToSwitch":
            case "RouterToRouter":
                if (cableType == "Крест" && standard1 != standard2)
                {
                    isCorrect = true;
                }
                else
                {
                    feedbackText.text = "Бірдей құрылғыларды қосу үшін әртүрлі стандарттары бар кроссовер кабелі қажет!";
                }
                break;
        }

        if (isCorrect)
        {
            man.score += 1;
            wipes.Play("InsertCabel");
            StartCoroutine(WaitForFiveSeconds());
        }
    }

    private IEnumerator WaitForFiveSeconds()
    {
        // Ждём 5 секунд
        yield return new WaitForSeconds(5f);
        Cursor.lockState = CursorLockMode.Locked;
        _player.SetActive(true);
        miniGame.SetActive(false);
    }

    private void ReturnToPlayer()
    {
        _player.SetActive(true);
        miniGame.SetActive(false);
    }
}
