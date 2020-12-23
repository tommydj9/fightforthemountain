using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public EnemyController enemy;
    public enum BodyParts
    {
        head,
        body,
        legs,
        arms,
        feet
    }

    public BodyParts bodyParts;

    public void Hit(float _damage)
    {
        try {
            enemy.life -= _damage;
            if (enemy.life <= 0)
            {
                enemy.Die();
            }
        }
        catch
        {
            Debug.LogWarning("EnemyController not connected!");
        }
        
        
    }



}
