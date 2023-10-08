using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private float _thresholdDistance;
    
    private LineRenderer _lineInstance;
    private int _positionIndex;
    private Desk _desk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Desk desk))
        {
            _desk = desk;
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Desk desk))
        {
            _desk = null;
            Deactivate();
        }
    }
    private void FixedUpdate()
    {
        if (_lineInstance)
        {
            Vector3 targetPosition = _desk.Plane.ClosestPointOnPlane(transform.position);
            _lineInstance.SetPosition(_positionIndex, targetPosition);

            float distance = Vector3.Distance(_lineInstance.GetPosition(_positionIndex - 1), targetPosition);
            if (distance > _thresholdDistance)
            {
                _lineInstance.positionCount++;
                _positionIndex++;
                _lineInstance.SetPosition(_positionIndex, targetPosition);
            }
        }
    }

    public void Activate()
    {
        _lineInstance = Instantiate(_linePrefab, transform.position, _desk.transform.rotation);
        Vector3 targetPosition = _desk.Plane.ClosestPointOnPlane(transform.position);
        _lineInstance.SetPosition(0, targetPosition);
        _lineInstance.SetPosition(1, targetPosition);
        _positionIndex++;
    }

    public void Deactivate()
    {
        _lineInstance = null;
        _positionIndex = 0;
    }


    public void setColorBlack()
    {
        _linePrefab.startColor = Color.black;
        _linePrefab.endColor = Color.black;
    }
    public void setColorWhite()
    {
        _linePrefab.startColor = Color.white;
        _linePrefab.endColor = Color.white;
    }


    public void deleteLines()
    {
        foreach (LineRenderer line in Object.FindObjectsOfType<LineRenderer>())
        {
            Destroy(line);
        }
    }
}
