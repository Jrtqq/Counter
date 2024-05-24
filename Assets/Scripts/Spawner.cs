using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    private Queue<T> _pool = new Queue<T>();

    public T Spawn(Vector3 position)
    {
        if (_pool.Count > 0)
        {
            T item = _pool.Dequeue();
            item.gameObject.SetActive(true);
            item.transform.position = position;

            return item;
        }
        else
        {
            T item = Instantiate(_prefab, position, Quaternion.identity);
            return item;
        }
    }

    public void Push(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
    }
}
