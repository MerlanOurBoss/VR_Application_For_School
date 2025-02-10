using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRJ45 : MonoBehaviour
{
    public GameObject RJ45Prefab;
    public GameObject Tip1;
    public GameObject Tip0_1;
    public GameObject RJ45HighLight;
    public Transform SpawnPosition;
    public GameObject PrefabRJ45_2;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RJ45"))
        {
            Destroy(other.gameObject);
            RJ45Prefab.SetActive(true);
            RJ45HighLight.SetActive(true);
            Instantiate(PrefabRJ45_2);
            Tip0_1.SetActive(true);  
            Tip1.SetActive(false);            
                      
        }
    }
}
