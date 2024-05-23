using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Cube : MonoBehaviour
{
    private CubeSpawner _spawner;
    private Material _material;

    private Color _defaultColor;
    private float _minDestroyTime = 2;
    private float _maxDestroyTime = 5;
    private bool _isExecuted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isExecuted == false && collision.collider.TryGetComponent(out Ground _))
        {
            StartCoroutine(nameof(InvokePush));
            _material.color = GetRandomColor();

            _isExecuted = true;
        }
    }

    public void Init(CubeSpawner spawner)
    {
        _spawner = spawner;

        _material = GetComponent<MeshRenderer>().material;
        _defaultColor = _material.color;
    }

    public void OnPush()
    {
        _material.color = _defaultColor;
        _isExecuted = false;
    }

    private IEnumerator InvokePush()
    {
        yield return new WaitForSeconds(Random.Range(_minDestroyTime, _maxDestroyTime));
        _spawner.Push(this);
    }

    private Color GetRandomColor() => new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
}
