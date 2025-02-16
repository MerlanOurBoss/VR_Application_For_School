using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRJ45 : MonoBehaviour
{
    public GameObject RJ45Prefab;
    public GameObject Tip1;
    public GameObject Tip2;
    public Transform SpawnPosition;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RJ45"))
        {
            Destroy(other.gameObject);
            RJ45Prefab.SetActive(true);
            Tip2.SetActive(true);  
            Tip1.SetActive(false);            
            Tip2.GetComponent<WaitForTouch>().isTouched = true;
        }
    }
}
