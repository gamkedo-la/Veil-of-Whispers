using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();  
    }

    private void OnTriggerEnter(Collider other)
    {
        String tag = this.gameObject.tag;
        if (other == myCollider) { return; }
        if(alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if(other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(1,tag);
        }
    }
}
