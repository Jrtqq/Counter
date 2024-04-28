using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Transform _transform;

    private float _explosionForce = 1000;
    private float _explosionRange = 10;

    private int _minSplitCubes = 2;
    private int _maxSplitCubes = 7;
    private float _splitChance = 1;

    private void Awake() => _transform = transform;

    private void OnMouseDown()
    {
        float randomNumber = Random.Range(0f, 1f);

        if (randomNumber <= _splitChance)
            Split();
        else
            Explode();

        Destroy(gameObject);
    }

    private void Init(float splitChance, Vector3 scale, float explosionForce, float explosionRange)
    {
        splitChance = Mathf.Clamp01(splitChance);

        _explosionForce = explosionForce;
        _explosionRange = explosionRange;
        _splitChance = splitChance;
        _transform.localScale = scale;
    }

    private void Split()
    {
        int amount = Random.Range(_minSplitCubes, _maxSplitCubes);

        for (int i = 0; i < amount; i++)
            Instantiate(_cubePrefab, _transform.position, Quaternion.identity)
                .Init(_splitChance / 2, _transform.localScale / 2, _explosionForce / 2, _explosionRange / 2);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _explosionRange);
        Rigidbody rigidbody;

        foreach (Collider collider in colliders)
            if (collider.TryGetComponent(out rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, _transform.position, _explosionRange);
    }
}
