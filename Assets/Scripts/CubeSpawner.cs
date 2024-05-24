using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Transform _spawnRange;
    [SerializeField] private BombSpawner _bombSpawner;

    private float _cooldown = 0.5f;
    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            _time = 0;
            Spawn(GetSpawnPoint()).Init(this, _bombSpawner);
        }
    }

    private Vector3 GetSpawnPoint() => new(
        Random.Range(-_spawnRange.position.x, _spawnRange.position.x),
        _spawnRange.position.y,
        Random.Range(-_spawnRange.position.z, _spawnRange.position.z));
}
