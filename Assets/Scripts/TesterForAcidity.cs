using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterForAcidity : MonoBehaviour
{
    [SerializeField] private GameObject tes;
    [SerializeField] private Material mat;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tester") 
        {
        tes.GetComponent<Renderer>().material = mat;
        }
    }
}
