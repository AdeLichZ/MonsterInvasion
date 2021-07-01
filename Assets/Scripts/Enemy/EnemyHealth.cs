using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] int hitPoints = 1;
        [SerializeField] EnemyType enemyType;

        private bool isAlive;

        public static event Action Removed;
        void Start()
        {
            isAlive = true;
        }
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
            isAlive = false;
            Destroy(gameObject);
            Removed();
        }
    }
}
