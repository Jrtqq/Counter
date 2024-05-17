using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Action<float> Changed;

    public float Value { get; private set; }

    public IEnumerator Count()
    {
        WaitForSeconds delay = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return delay;

            Value++;
            Changed?.Invoke(Value);
        }
    }
}
