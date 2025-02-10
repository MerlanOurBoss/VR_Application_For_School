using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChanger : MonoBehaviour
{
    private Renderer objectRenderer;
    private Material material;
    private Color originalColor;

    // ��������� � �������� �����
    private float startAlpha = 0.15f;
    private float endAlpha = 0.3f;
    private float changeSpeed = 0.3f;  // �������� ���������

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        material = objectRenderer.material;
        originalColor = material.color;

        // ������������� ��������� �����
        SetAlpha(startAlpha);
    }

    private void Update()
    {
        float currentAlpha = Mathf.PingPong(Time.time * changeSpeed, endAlpha - startAlpha) + startAlpha;
        SetAlpha(currentAlpha);
    }

    private void SetAlpha(float alpha)
    {
        // �������� �����-�����
        Color newColor = originalColor;
        newColor.a = alpha;
        material.color = newColor;
    }
}
