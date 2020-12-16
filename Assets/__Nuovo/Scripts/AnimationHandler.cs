using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public DamageCollider handDamageCollider;
    

    public void EnableHandDamageCollider()
    {
        handDamageCollider.EnableDamgeCollider();
    }
    
    public void DisableHandDamageCollider()
    {
        handDamageCollider.DisableDamgeCollider();
    }
}
