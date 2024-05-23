using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private const string MasterGroup = "Master";
    private const string SoundButtonsGroup = "Buttons";
    private const string MusicGroup = "Music";

    [SerializeField] private AudioMixer _mixer;

    private float _maxVolume = 20;
    private float _minVolume = -80;

    public void ChangeMasterVolume(float value)
    {
        _mixer.SetFloat(MasterGroup, ConvertToVolume(value));
    }

    public void ChangeButtonsVolume(float value)
    {
        _mixer.SetFloat(SoundButtonsGroup, ConvertToVolume(value));
    }

    public void ChangeMusicVolume(float value)
    {
        _mixer.SetFloat(MusicGroup, ConvertToVolume(value));
    }

    public void SwitchVolume()
    {
        _mixer.GetFloat(MasterGroup, out float currentValue);
        _mixer.SetFloat(MasterGroup, currentValue == _minVolume ? ConvertToVolume(1) : ConvertToVolume(0));
    }

    private float ConvertToVolume(float value)
    {
        value = Mathf.Clamp01(value);
        return value * (_maxVolume - _minVolume) + _minVolume;
    }
}
