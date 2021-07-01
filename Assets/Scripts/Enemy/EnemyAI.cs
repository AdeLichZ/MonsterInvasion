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
        [SerializeField] bool isMoving;
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            isAlive = true;
            StartCoroutine(MoveToRandomPoint());
        }

        void Update()
        {
            //MovingPermanently();
        }

        private void MovingPermanently()
        {
            if (isAlive)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.distance < obstacleRange)
                    {
                        RotateProcess();
                    }
                }
            }
        }

        private void RotateProcess()
        {
            float angle = Random.Range(-110, 100);   // to do smooth rotate
            transform.Rotate(0, angle, 0);
        }
        IEnumerator MoveToRandomPoint()
        {
            Debug.Log("Spawn");
            yield return new WaitForSeconds(2f);
            while(true)
            {
                isMoving = false;
                xPoint = Random.Range(-20, 20);
                zPoint = Random.Range(-20, 20);

                Vector3 randomPoint = new Vector3(xPoint, 2, zPoint);
                transform.position = Vector3.MoveTowards(transform.position, randomPoint, speed);
                nav.SetDestination(transform.position);
                if(transform.position == randomPoint)
                {
                    Debug.Log("stop");
                }
                yield return new WaitForSeconds(2f);
            }
        }
    }

}
