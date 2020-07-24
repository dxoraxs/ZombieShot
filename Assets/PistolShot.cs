using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PistolShot : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform pointShot;
    private BulletSetting[] bulletSettings;

    private int countSetting = 0;
    private RaycastMouseDownPoint raycastMouseDownPoint;
    
    private void Start()
    {
        raycastMouseDownPoint = GetComponent<RaycastMouseDownPoint>();
        raycastMouseDownPoint.mouseDown += Shot;
        bulletSettings = GameController.Instance.GetBulletSettings;
    }

    private void Shot(Vector3 target)
    {
        var pointShotPosition = pointShot.position;
        var bullet = Instantiate(bulletPrefab, pointShotPosition, Quaternion.identity);
        var direction = (target - pointShotPosition).normalized;
        bullet.InitBullet(bulletSettings[countSetting], direction);
        Destroy(bullet.gameObject, 3f);
        NextSettings();
    }

    private void NextSettings()
    {
        countSetting++;
        if (countSetting >= bulletSettings.Length) countSetting = 0;
    }
}
