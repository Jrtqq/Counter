using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _exlosionRadius;
    [SerializeField] private float _exlosionForce;

    private BombSpawner _spawner;
    private Material _material;
    private Transform _transform;

    private float _vanishStep;

    public void Init(BombSpawner spawner)
    {
        float minExplosionTime = 2;
        float maxExplosionTime = 5;
        _vanishStep = 1 / Random.Range(minExplosionTime, maxExplosionTime);

        _transform = transform;
        _spawner = spawner;
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (_material.color.a <= 0)
        {
            Explode();
            return;
        }

        _material.color -= new Color(0, 0, 0, _vanishStep * Time.deltaTime);
    }

    public void OnPush()
    {
        _material.color += new Color(0, 0, 0, 1);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _exlosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_exlosionForce, _transform.position, _exlosionRadius);
        }

        _spawner.Push(this);
    }
}
