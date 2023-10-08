using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Hand : MonoBehaviour
{
    [SerializeField] private InputActionReference grib;
    [SerializeField] private InputActionReference trigger;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        grib.action.performed += AnimateGrib;
        grib.action.canceled += AnimateGrib;
        trigger.action.performed += AnimateTrigg;
        trigger.action.canceled += AnimateTrigg;
    }      
    private void OnDisable()
    {
        grib.action.performed -= AnimateGrib;
        grib.action.canceled += AnimateGrib;
        trigger.action.performed += AnimateTrigg;
        trigger.action.canceled += AnimateTrigg;
    } 
    private void AnimateGrib(InputAction.CallbackContext obj)
    {
        animator.SetFloat("Grib", obj.ReadValue<float>());
    }
    private void AnimateTrigg(InputAction.CallbackContext obj)
    {
        animator.SetFloat("Trigger", obj.ReadValue<float>());
    }

}
