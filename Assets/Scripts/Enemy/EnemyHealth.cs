using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] int hitPoints = 1;

        public static event Action Removed;
        public void TakeDamage(int damage)
        {
            hitPoints = hitPoints - damage;
            if(hitPoints <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            EnemyAI enemyAI = GetComponent<EnemyAI>();
            Destroy(gameObject);
            Removed();
        }
    }
}
