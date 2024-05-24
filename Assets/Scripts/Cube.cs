using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;
    private BombSpawner _bombSpawner;

    private Material _material;
    private Transform _transform;

    private Color _defaultColor;
    private float _minDestroyTime = 2;
    private float _maxDestroyTime = 5;
    private bool _isExecuted = false;

    public void Init(CubeSpawner cubeSpawner, BombSpawner bombSpawner)
    {
        if (_cubeSpawner == null || _bombSpawner == null)
        {
            _cubeSpawner = cubeSpawner;
            _bombSpawner = bombSpawner;

            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
            _transform = transform;
        }

        _material.color = _defaultColor;
        _isExecuted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isExecuted == false && collision.collider.TryGetComponent(out Ground _))
        {
            StartCoroutine(nameof(InvokePush));
            _material.color = GetRandomColor();

            _isExecuted = true;
        }
    }

    private IEnumerator InvokePush()
    {
        yield return new WaitForSeconds(Random.Range(_minDestroyTime, _maxDestroyTime));
        _bombSpawner.Spawn(_transform.position);
        _cubeSpawner.Push(this);
    }

    private Color GetRandomColor() => new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
}