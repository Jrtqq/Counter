using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [SerializeField] private SpringJoint _catapult;
    [SerializeField] private Rigidbody _catapultRigidbody;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Rigidbody _projectile;

    private float _stretchedSpring = 50;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _catapultRigidbody.WakeUp();
            _catapult.spring = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _catapultRigidbody.WakeUp();
            _catapult.spring = _stretchedSpring;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _projectile.velocity = Vector3.zero;
            _projectile.angularVelocity = Vector3.zero;
            _projectile.rotation = Quaternion.identity;
            _projectile.transform.position = _projectileSpawnPoint.position;
        }
    }
}
