using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidExplode : MonoBehaviour
{
    [SerializeField] private LiquidController _liquidColor;
    [SerializeField] private GameObject _fire;
    [SerializeField] private List<GameObject> _bottles;

    void Start()
    {
        _liquidColor = GetComponent<LiquidController>();
    }
    void Update()
    {
        LiquidExplosion();
    }

    private void LiquidExplosion()
    {
        if (_liquidColor._color == _liquidColor._changeTheColor)
        {
            StartCoroutine(StartTrigger(true));
        }
    }

    private IEnumerator StartTrigger(bool a)
    {
        yield return new WaitForSeconds(4f);
        _fire.SetActive(a);
        foreach (GameObject tmp in _bottles)
        {
            Destroy(tmp);
        }
    }
}
