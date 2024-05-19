using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _spawnRange;

    private Queue<Cube> _pool = new Queue<Cube>();

    private float _cooldown = 0.5f;
    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            Spawn();
        }
    }

    public void Push(Cube cube)
    {
        cube.OnPush();
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }

    private void Spawn()
    {
        if (_pool.Count > 0)
        {
            Cube cube = _pool.Dequeue();
            cube.gameObject.SetActive(true);
            cube.transform.position = GetSpawnPoint();
        }
        else
        {
            Instantiate(_prefab, GetSpawnPoint(), Quaternion.identity).Init(this);
        }
    }

    private Vector3 GetSpawnPoint() => new(
        Random.Range(-_spawnRange.position.x, _spawnRange.position.x),
        _spawnRange.position.y,
        Random.Range(-_spawnRange.position.z, _spawnRange.position.z));
}
