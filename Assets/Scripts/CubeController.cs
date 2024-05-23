using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Transform _spawnRange;

    private ObjectPool<Cube> _cubePool;
    private ObjectPool<Bomb> _bombPool;
    private float _cooldown = 0.5f;
    private float _time = 0;

    private void Awake()
    {
        _cubePool = new(_cube);
        _bombPool = new(_bomb);
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            _time = 0;
            _cubePool.Release(GetSpawnPoint()).Pushing += SpawnBomb;
        }
    }

    private Vector3 GetSpawnPoint() => new(
        Random.Range(-_spawnRange.position.x, _spawnRange.position.x),
        _spawnRange.position.y,
        Random.Range(-_spawnRange.position.z, _spawnRange.position.z));

    private void SpawnBomb(IPoolObject item)
    {
        _bombPool.Release((item as MonoBehaviour).transform.position);
    }
}
