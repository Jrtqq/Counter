using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    private const string MouseY = "Mouse Y";
    private const string MouseX = "Mouse X";

    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private Transform _camera;

    private float _cameraMinY = -89;
    private float _cameraMaxY = 89;
    private float _cameraAngle;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        RotateCamera();
        RotateCharacter();
    }

    private void RotateCamera()
    {
        _cameraAngle -= Input.GetAxis(MouseY) * _sensitivityY;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _cameraMinY, _cameraMaxY);

        _camera.localEulerAngles = Vector3.right * _cameraAngle;
    }

    private void RotateCharacter()
    {
        float rotation = Input.GetAxis(MouseX) * _sensitivityX;
        _transform.localEulerAngles += new Vector3(0, rotation, 0);
    }
}
