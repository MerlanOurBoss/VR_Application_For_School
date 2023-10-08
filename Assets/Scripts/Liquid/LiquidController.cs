using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LiquidController : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _fill;
    public Color _color;
    public Color _changeTheColor;
    [SerializeField] private Transform _bottleNeck;
    [SerializeField] private float _radius;
    [SerializeField] private LineRenderer _stream;

    private List<Vector3> _vertices;
    private float _objectHeight;
    private float _objectCenter;
    private Vector3 _bottleNeckLowestPoint;

    private void Awake()
    {
        _vertices = new List<Vector3>();
        _meshFilter.sharedMesh.GetVertices(_vertices);
    }

    private void FixedUpdate()
    {
        CalculateHeight();

        float overflow = GetOverflow();
        print(overflow);
        if (overflow > 0.01f && _fill > 0)
        {
            _stream.gameObject.SetActive(true);
            PourLiquid(overflow);
        }
        else
        {
            _stream.gameObject.SetActive(false);
        }
        
        UpdateShader();
    }

    private void CalculateHeight()
    {
        float maxHeight = _vertices.Max(v => _meshFilter.transform.TransformPoint(v).y);
        float minHeight = _vertices.Min(v => _meshFilter.transform.TransformPoint(v).y);

        _objectHeight = maxHeight - minHeight;
        _objectCenter = (maxHeight + minHeight) / 2;
    }

    private void UpdateShader()
    {
        _renderer.material.SetFloat("_ObjectHeight", _objectHeight);
        _renderer.material.SetFloat("_ObjectCenter", _objectCenter);
        _renderer.material.SetFloat("_Fill", _fill);
        _renderer.material.SetColor("_Color", _color);
    }

    private Vector3 GetBottleNeckLowestPoint()
    {
        return Vector3.ProjectOnPlane(Vector3.down, _bottleNeck.up).normalized * _radius;
    }

    private float GetWaterLevel()
    {
        return _objectCenter - _objectHeight / 2 + _fill * _objectHeight;
    }

    private float GetOverflow()
    {
        _bottleNeckLowestPoint = GetBottleNeckLowestPoint() + _bottleNeck.position;
        float waterLevel = GetWaterLevel();
        return waterLevel - _bottleNeckLowestPoint.y;
    }

    private void PourLiquid(float amount)
    {
        _fill -= amount * 0.01f;
        if (_fill < 0.01f) _fill = 0;

        RaycastHit hit;
        if (Physics.Raycast(_bottleNeckLowestPoint, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.rigidbody)
            {    
                if (hit.rigidbody.TryGetComponent(out LiquidController liquid))
                {
                    liquid.AddLiquid(amount, _changeTheColor);
                }
            }

            _stream.startColor = _color;
            _stream.endColor = _color;
            _stream.startWidth = amount;
            _stream.SetPosition(0, _bottleNeckLowestPoint);
            _stream.SetPosition(1, hit.point);
        }
    }

    public void AddLiquid(float amount, Color color)
    {
        _fill += amount * 0.01f;
        _color = Color.Lerp(_color, color, (float)(Time.deltaTime + 0.5));
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(_bottleNeck.position, _bottleNeck.up, _radius, 4);
    }
#endif
}
