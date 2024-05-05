using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }

    public bool Check() => Physics.OverlapSphere(transform.position, _collider.radius, _ground).Length > 0;
}
