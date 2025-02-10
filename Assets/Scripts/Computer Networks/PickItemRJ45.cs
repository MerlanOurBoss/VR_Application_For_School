using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemRJ45 : MonoBehaviour
{
    public GameObject Tip0;
    public GameObject Tip1;

    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.useGravity == false)
        {
            Tip0.SetActive(false);
            Tip1.SetActive(true);
        }
    }
}
