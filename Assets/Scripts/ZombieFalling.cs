using System.Collections.Generic;
using UnityEngine;

public class ZombieFalling : MonoBehaviour
{
    private Animator animator;
    private List<Rigidbody> partBody;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        partBody = new List<Rigidbody>();
        AddComponentChildren(transform);
    }

    private void ShotZombie()
    {
        GameController.Instance.StartDeceleration();
        PartResetVelocity();
        animator.enabled = false;
    }

    public void RestartZombie()
    {
        animator.enabled = true;
        PartResetVelocity();
    }

    private void PartResetVelocity()
    {
        foreach (var part in partBody)
        {
            part.velocity = Vector3.zero;
        }
    }

    private void AddComponentChildren(Transform transformChildren)
    {
        if (transformChildren.childCount > 0)
        {
            foreach (Transform child in transformChildren)
            {
                if (child.TryGetComponent(out Collider collider))
                {
                    child.gameObject.AddComponent<PartBodyTrigger>().triggerEnter += ShotZombie;
                    partBody.Add(child.GetComponent<Rigidbody>());
                }
                AddComponentChildren(child);
            } 
        }
    }
}
