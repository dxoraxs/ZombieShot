using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Create bullet")]
public class BulletSetting : ScriptableObject
{
    [SerializeField] private float force;

    public float Force => force;
}
