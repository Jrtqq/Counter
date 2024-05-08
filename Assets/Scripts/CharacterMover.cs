using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _camera;
    [SerializeField] private GroundChecker _groundChecker;

    private Vector3 _verticalVelocity = Vector3.down;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveHorizontal()
    {
        if (_groundChecker.IsGrounded())
        {
            Vector3 forward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_camera.right, Vector3.up).normalized;

            Vector3 direction = forward * Input.GetAxis(Vertical) + right * Input.GetAxis(Horizontal);
            direction = direction * _speed * Time.deltaTime;

            _controller.Move(direction);
        }
        else
        {
            _controller.Move(_controller.velocity * Time.deltaTime);
        }
    }
 
    private void MoveVertical()
    {
        if (_groundChecker.IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _verticalVelocity = Vector3.up * _jumpForce;
            else
                _verticalVelocity = Vector3.down;
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
        }

        _controller.Move(_verticalVelocity * Time.deltaTime);
    }
}
