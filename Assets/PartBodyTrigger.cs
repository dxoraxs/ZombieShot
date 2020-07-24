using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBodyTrigger : MonoBehaviour
{
    public Action triggerEnter;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            triggerEnter?.Invoke();
            rigidbody.AddForce(5 * bullet.Impulse, ForceMode.Impulse);
            bullet.CollisionBullet();
        }
    }
}
