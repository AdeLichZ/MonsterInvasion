using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WanderingAI : MonoBehaviour
{
    NavMeshAgent nav;
    Animator animator;
    private CapsuleCollider collider;
    [SerializeField] int hitPoints = 1;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float obstacleRange = 4f;
    [SerializeField] private float xPoint, zPoint;
    private bool isAlive;
    [SerializeField] bool isReached;

    public static event Action Removed;
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
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
    private void MovingPermanently()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 2, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                RotateProcess();
            }
        }

    }
    private void RotateProcess()
    {
        float angle = Random.Range(-110, 100);   // to do smooth rotate

        transform.Rotate(0, angle, 0);
    }
    public void TakeDamage(int damage)
    {
        hitPoints = hitPoints - damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(collider);
        isAlive = false;
        animator.SetBool("isDead", true);
        Removed();
        nav.isStopped = true;
        Destroy(nav);
        Destroy(gameObject, 2.5f);
    }
}
