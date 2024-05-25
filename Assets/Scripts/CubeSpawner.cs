using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Transform _spawnRange;
    [SerializeField] private BombSpawner _bombSpawner;

    public bool IsWorking = true;

    private float _cooldown = 0.5f;

    private void Start()
    {
        StartCoroutine(SpawnLooped());
    }

    private IEnumerator SpawnLooped()
    {
        WaitForSeconds delay = new WaitForSeconds(_cooldown);

        while (IsWorking)
        {
            Spawn(GetSpawnPoint()).Init(this, _bombSpawner);
            yield return delay;
        }
    }

    private Vector3 GetSpawnPoint() => new(
        Random.Range(-_spawnRange.position.x, _spawnRange.position.x),
        _spawnRange.position.y,
        Random.Range(-_spawnRange.position.z, _spawnRange.position.z));
}
