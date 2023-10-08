using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;
    [SerializeField] private Transform _head;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private LayerMask _groundLayers;

    private CharacterController _controller;
    private bool _isGrounded;
    private float fallSpeed;
    

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _move.action.performed += Move;
    }

    private void Update()
    {
        CheckGround();
        Fall();
    }
    private void Move(InputAction.CallbackContext moveContext)
    {
        Vector3 moveVector = (moveContext.ReadValue<Vector2>() * Time.deltaTime);
        moveVector.z = moveVector.y;
        moveVector.y = 0;

        Vector3 lookDirection = Vector3.ProjectOnPlane(_head.forward, Vector3.up).normalized;
        float angle = Vector3.SignedAngle(transform.forward, lookDirection, Vector3.up);
        moveVector = Quaternion.Euler(0, angle, 0) * moveVector;

        _controller.Move(moveVector);
    }

    private void Fall()
    {
        if (!_isGrounded) fallSpeed += _gravity * Time.deltaTime;
        else fallSpeed = 0;

        _controller.Move(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void CheckGround()
    {
        Vector3 origin = transform.TransformPoint(_controller.center);
        _isGrounded =
            Physics.SphereCast(origin, _controller.radius, Vector3.down, out RaycastHit hit, _controller.center.y, _groundLayers);
        print(hit.collider);
    }
}
