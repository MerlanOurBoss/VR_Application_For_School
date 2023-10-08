using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    private bool _isInVacuum;
    private Rigidbody _rb;

    public bool IsInVacuum
    {
        get
        {
            return _isInVacuum;
        }
        set
        {
            _isInVacuum = value;
            UpdateRigidbody();
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void UpdateRigidbody()
    {
        _rb.drag = _isInVacuum ? 0 : 10;
    }
}
