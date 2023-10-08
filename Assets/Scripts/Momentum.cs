using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Momentum : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj1;
    public float _force = 20f;
    public Text _text;

    private Rigidbody _rigidbody;
    public Slider _slider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        tex();
    }

    public void back()
    {
        obj1.transform.position = new Vector3(9, 4, 1);
        obj.transform.position = new Vector3(9, 4, -4);
    }

    public void Push()
    {
        _rigidbody.AddForce(Vector3.forward * _slider.value, ForceMode.Impulse);
    }

    public void ChangeSldierValue(float _force)
    {
        _slider.value += _force;
    }

    public void tex()
    {
        _text.GetComponent<Text>().text = _slider.value.ToString();
    }
}
