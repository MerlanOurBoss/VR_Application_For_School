using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IPv4Address : MonoBehaviour
{
    // Ссылка на TextMeshPro GUI
    public TextMeshProUGUI textMeshPro;
    public readonly string randomIPv4;
    private void Awake()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro компонент не привязан!");
            return;
        }

        // Генерация случайного IPv4 адреса
        string randomIPv4 = GenerateRandomIPv4();

        // Присваиваем текст компоненту TextMeshPro
        textMeshPro.text = randomIPv4;
    }

    private string GenerateRandomIPv4()
    {
        // Создаем 4 случайных числа от 0 до 255
        int octet1 = Random.Range(0, 256);
        int octet2 = Random.Range(0, 256);
        int octet3 = Random.Range(0, 256);
        int octet4 = Random.Range(0, 256);

        // Формируем IPv4 адрес
        return $"{octet1}.{octet2}.{octet3}.{octet4}";
    }
}
