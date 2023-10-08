using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentForText : MonoBehaviour
{
    public Rigidbody rg;
    public GameObject tx;
    void Start()
    {
        Rigidbody rg = GetComponent<Rigidbody>();
        tex();
    }

    void Update()
    {
        tex();
    }
    void tex()
    {
        tx.GetComponent<Text>().text = rg.mass.ToString();
    }
}
