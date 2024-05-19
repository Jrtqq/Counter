using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;

    private Queue<Bomb> _pool = new Queue<Bomb>();

    public void Spawn(Vector3 position)
    {
        if (_pool.Count > 0)
        {
            Bomb bomb = _pool.Dequeue();
            bomb.gameObject.SetActive(true);
            bomb.transform.position = position;
        }
        else
        {
            Instantiate(_prefab, position, Quaternion.identity).Init(this);
        }
    }

    public void Push(Bomb bomb)
    {
        bomb.OnPush();
        bomb.gameObject.SetActive(false);
        _pool.Enqueue(bomb);
    }
}
