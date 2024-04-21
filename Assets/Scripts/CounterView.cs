using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _interface;

    private void OnEnable()
    {
        _counter.Changed += UpdateCounter;
    }

    private void OnDisable()
    {
        _counter.Changed -= UpdateCounter;
    }

    private void UpdateCounter(float value)
    {
        _interface.text = value.ToString();
    }
}
