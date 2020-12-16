using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public float damage;

    private Collider damageCollider;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamgeCollider()
    {
        damageCollider.enabled = true;
    }
    
    public void DisableDamgeCollider()
    {
        damageCollider.enabled = false;
    }

    
}
