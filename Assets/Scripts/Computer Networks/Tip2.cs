using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip2 : MonoBehaviour
{
    public GameObject RJ45HighLigth;
    public GameObject RJ45Mesh;
    public GameObject Tip0_1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RJ45"))
        {
            Destroy(other.gameObject);
            RJ45Mesh.SetActive(true);
            Tip0_1.SetActive(false);
            gameObject.transform.GetComponentInParent<WaitForTouch>().isTouched = false;
        }
    }
}
