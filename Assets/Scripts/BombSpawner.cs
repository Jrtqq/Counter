using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    public new void Spawn(Vector3 position)
    {
        base.Spawn(position).Init(this);
    }
}
