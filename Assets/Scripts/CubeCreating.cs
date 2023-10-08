using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreating : MonoBehaviour
{
    public GameObject[] Cubes;
    public Transform placeForCube;
    public int randomIndex;
    public Vector3 randomSpawnPosition;

    public void Update()
    {
        randomIndex = Random.Range(0, Cubes.Length);
        randomSpawnPosition = new Vector3(Random.Range(7,10), 5, Random.Range(-6,3));
    }
    public void Creat()
    {
        Instantiate(Cubes[randomIndex], randomSpawnPosition, Quaternion.identity);
    }

    public void DestroyCubes()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Box"))
        {
            Destroy(o);
        }
    }
}
