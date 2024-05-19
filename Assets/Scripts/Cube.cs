using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

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
        _cubeSpawner = cubeSpawner;
        _bombSpawner = bombSpawner;
        _transform = transform;

        _material = GetComponent<MeshRenderer>().material;
        _defaultColor = _material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isExecuted == false)
        {
            StartCoroutine(nameof(InvokePush), Random.Range(_minDestroyTime, _maxDestroyTime));
            _material.color = GetRandomColor();

            _isExecuted = true;
        }
    }

    public void OnPush()
    {
        _material.color = _defaultColor;
        _isExecuted = false;
    }

    private IEnumerator InvokePush(float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
            yield return null;

        _bombSpawner.Spawn(_transform.position);
        _cubeSpawner.Push(this);
    }

    private Color GetRandomColor() => new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
}
