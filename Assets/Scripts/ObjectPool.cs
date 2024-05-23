using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
{
    private T _prefab;
    private Queue<T> _pool = new Queue<T>();

    public ObjectPool(T prefab)
    {
        _prefab = prefab;
    }

    public T Release(Vector3 position)
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
            T item = Object.Instantiate(_prefab, position, Quaternion.identity);
            item.Pushing += OnItemPushing;

            return item;
        }
    }

    private void OnItemPushing(IPoolObject item)
    {
        if (item != null)
        {
            item.OnPush();
            Push(item as T);
        }
    }

    private void Push(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
    }
}
