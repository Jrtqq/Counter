using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    public event Action<IPoolObject> Pushing;

    void OnPush();
}
