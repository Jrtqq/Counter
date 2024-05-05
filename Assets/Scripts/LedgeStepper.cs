using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeStepper : MonoBehaviour
{
    [SerializeField] private Rigidbody _character;
    [SerializeField] private BoxCollider _obstacleChecker;
    [SerializeField] private float _liftForce;
    [SerializeField] private LayerMask _ground;

    private int _groundLayerNumber = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _groundLayerNumber)
        {
            if (Physics.OverlapBox(_obstacleChecker.gameObject.transform.position, _obstacleChecker.bounds.extents, Quaternion.identity, _ground).Length <= 0)
            {
                _character.AddForce(Vector3.up * _liftForce);
            }
        }
    }
}
