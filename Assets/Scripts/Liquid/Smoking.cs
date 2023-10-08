using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoking : MonoBehaviour
{
    [SerializeField] private LiquidController _liquidColor;
    [SerializeField] private GameObject _smoke;

    public float stopSmoke = 10f;

    void Start()
    {
        _liquidColor = GetComponent<LiquidController>();
    }
    void Update()
    {
        LiquidSmoking();
    }

    private void LiquidSmoking()
    {
        if (_liquidColor._color == Color.blue)
        {
            StartCoroutine(StartTrigger(true));
            Invoke("stopTheSmoke", stopSmoke);
        }
    }

    private IEnumerator StartTrigger(bool a)
    {
        yield return new WaitForSeconds(4f);
        _smoke.SetActive(a);
    }

    private void stopTheSmoke()
    {
        StopAllCoroutines();
        _smoke.SetActive(false);
    }
}
