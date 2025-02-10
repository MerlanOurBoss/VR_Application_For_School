using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IPAddressGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetIPText; // Для отображения целевого IP
    [SerializeField] private TextMeshProUGUI resultText;  // Для подсказки результата

    [SerializeField] private TextMeshProUGUI timerText;    // Для отображения таймера
    [SerializeField] private float maxTime = 120f;

    private List<string> allIPs = new List<string>(); // Хранит все IP-адреса
    private string targetIP; // Случайно выбранный целевой IP
    public bool isStarted = false;
    private bool isGameOver = false;

    private float remainingTime; // Оставшееся время
    private bool isTimerRunning = true;

    private void Start()
    {
        IPv4Address[] ipScripts = FindObjectsOfType<IPv4Address>();
        foreach (IPv4Address script in ipScripts)
        {
            allIPs.Add(script.textMeshPro.text);
        }

        if (allIPs.Count == 0)
        {
            Debug.LogError("Нет IP-адресов для игры!");
            return;
        }
        StartTimer();
    }
    private void Update()
    {
        if (isStarted && !isGameOver)
        {
            NextTargetIP();
            isStarted = false;
        }
        if (isTimerRunning)
        {
            UpdateTimer();
        }
        else if (!isTimerRunning)
        {
            EndGame();
        }
    }

    public void NextTargetIP()
    {
        if (isGameOver) return;

        if (allIPs.Count > 0)
        {
            targetIP = allIPs[Random.Range(0, allIPs.Count)];

            targetIPText.text = "Мына IP-ді табыңыз: " + targetIP;
            resultText.text = "";
        }
        else
        {
            EndGame();
        }
    }

    public void CheckIPAddress(string playerChoice)
    {
        Debug.Log(playerChoice + " " + targetIP);

        if (playerChoice == targetIP)
        {
            resultText.text = "Дұрыс! Сіз IP-ді таптыңыз: " + targetIP;

            allIPs.Remove(targetIP);

            StartCoroutine(LoadNextIP());
        }
        else
        {
            resultText.text = "Дұрыс емес! Қайтадан байқап көріңіз.";
        }
    }

    private IEnumerator LoadNextIP()
    {
        yield return new WaitForSeconds(2.0f);
        NextTargetIP();
    }
    private void StartTimer()
    {
        if (isGameOver) return;

        remainingTime = maxTime;
        isTimerRunning = true;
        UpdateTimerText();
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;
        UpdateTimerText();

        if (remainingTime <= 0)
        {
            OnTimeOut();
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Қалған уақыт: " + Mathf.Ceil(remainingTime).ToString();
    }

    private void OnTimeOut()
    {
        StopTimer();
    }

    private void EndGame()
    {
        isGameOver = true; // Устанавливаем флаг завершения игры
        targetIPText.text = "Ойын аяқталды! барлық IP мекенжайлары табылды.";
        resultText.text = "";
        timerText.text = "";
        StopTimer();
    }
}
