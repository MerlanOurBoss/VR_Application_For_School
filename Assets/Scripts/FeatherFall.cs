using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFall : MonoBehaviour
{
    [SerializeField] private Rigidbody rg;


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Feather feather))
            feather.IsInVacuum = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Feather feather))
            feather.IsInVacuum = true;
    }

}
