using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private float force;
    private Vector3 direction;

    public Vector3 Impulse => force * direction;

    public void InitBullet(BulletSetting setting, Vector3 direction)
    {
        force = setting.Force;
        this.direction = direction;
    }

    public void CollisionBullet()
    {
        meshRenderer.enabled = false;
        Destroy(this);
    }

    private void Update()
    {
        transform.Translate(direction * (10 * Time.deltaTime));
    }
}
