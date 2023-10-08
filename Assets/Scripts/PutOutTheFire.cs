using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PutOutTheFire : MonoBehaviour
{
    private ParticleSystem _particalSystem;
    ParticleSystem.EmissionModule _emissionModule;
    void Start()
    {
        _particalSystem = GetComponent<ParticleSystem>();
        _emissionModule = _particalSystem.emission;
    }
    private void Update()
    {
        if(_emissionModule.rateOverTime.constant == 0)
        {
            _particalSystem.Stop();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Fire"))
        {
            _emissionModule.rateOverTime = _emissionModule.rateOverTime.constant - 0.5f;
            Debug.Log(_emissionModule.rateOverTime.constant);
        }
    }
}
