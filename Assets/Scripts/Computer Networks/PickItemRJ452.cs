using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemRJ452 : MonoBehaviour
{
    public GameObject tip2;

    private Rigidbody _rigidbody;
    private void Start()
    {
        tip2 = GameObject.FindGameObjectWithTag("Tip2");
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.useGravity == false)
        {
            tip2.GetComponent<WaitForTouch>().isTouched = true;
        }
    }
}
