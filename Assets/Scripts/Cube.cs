using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _splitForce = 500;
    private int _minSplitCubes = 2;
    private int _maxSplitCubes = 7;

    private float _splitChance = 1;

    public Rigidbody Init(float splitChance, Vector3 scale)
    {
        splitChance = Mathf.Clamp01(splitChance);

        _splitChance = splitChance;
        transform.localScale = scale;

        return GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        float randomNumber = Random.Range(0f, 1f);

        if (randomNumber <= _splitChance)
            Split();

        Destroy(gameObject);
    }

    private void Split()
    {
        int amount = Random.Range(_minSplitCubes, _maxSplitCubes);

        for (int i = 0; i < amount; i++)
        {
            Instantiate(_cubePrefab, transform.position, Quaternion.identity)
                .Init(_splitChance / 2, transform.localScale / 2)
                .AddExplosionForce(_splitForce, transform.position, 0);
        }
    }
}
