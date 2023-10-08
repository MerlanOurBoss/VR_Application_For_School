using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private float _planeBias;

    private Plane _plane;

    public Plane Plane => _plane;

    private void Awake()
    {
        _plane = new Plane(transform.forward, transform.position + transform.forward * _planeBias);
    }
}
