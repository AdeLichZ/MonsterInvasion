using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        NavMeshAgent nav;
        Animator animator;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float obstacleRange = 4f;
        [SerializeField] private float xPoint, zPoint;
        private bool isAlive;
        [SerializeField] bool isReached;
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            isAlive = true;
            StartCoroutine(MoveToRandomPoint());
        }
        private void Update()
        {
            if (!isReached)
            {
                animator.SetBool("isRunning", true);
            }
            if (isReached)
            {
                animator.SetBool("isRunning", false);
            }
        }
        // генерация случайной точки назначение для navMeshAgent
        IEnumerator MoveToRandomPoint()
        {
            yield return new WaitForSeconds(2f);
            while (isAlive)
            {
                if (isReached)
                {
                    xPoint = Random.Range(-20, 20);
                    zPoint = Random.Range(-20, 20);
                    isReached = false;
                }
                Vector3 randomPoint = new Vector3(xPoint, transform.position.y, zPoint);
                nav.SetDestination(randomPoint);
                if (nav.transform.position == randomPoint)
                {
                    isReached = true;
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
