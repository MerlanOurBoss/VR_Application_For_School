using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IPv4Address : MonoBehaviour
{
    // ������ �� TextMeshPro GUI
    public TextMeshProUGUI textMeshPro;
    public readonly string randomIPv4;
    private void Awake()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro ��������� �� ��������!");
            return;
        }

        // ��������� ���������� IPv4 ������
        string randomIPv4 = GenerateRandomIPv4();

        // ����������� ����� ���������� TextMeshPro
        textMeshPro.text = randomIPv4;
    }

    private string GenerateRandomIPv4()
    {
        // ������� 4 ��������� ����� �� 0 �� 255
        int octet1 = Random.Range(0, 256);
        int octet2 = Random.Range(0, 256);
        int octet3 = Random.Range(0, 256);
        int octet4 = Random.Range(0, 256);

        // ��������� IPv4 �����
        return $"{octet1}.{octet2}.{octet3}.{octet4}";
    }
}
