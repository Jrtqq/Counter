using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidbodyMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private float _stopDistance = 2;
    private float _stopSpeed = 5;

    private Rigidbody _rigidbody;

    private Vector3 Path => _target.position - transform.position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity += Physics.gravity * Time.deltaTime;

        if (Path.magnitude > _stopDistance)
            _rigidbody.velocity += Path.normalized * _speed * Time.deltaTime;
        else
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, Vector3.zero, _stopSpeed * Time.deltaTime);
    }
}
