using General;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{

    public class EnemyAI : MonoBehaviour
    {
        Animator animator;
        CapsuleCollider collider;
        public HealthBar healthBar;

        [SerializeField]private int maxHitPoints;
        private int currentHitPoints;
        public float speed = 5f;
        private float obstacleRange = 2f;
        public bool isAlive;
        public bool isReady;
        public float gameTimeCount;

        public static event Action Removed;
        public static event Action Upgraded;
        private void Awake()
        {
            gameTimeCount = Time.timeSinceLevelLoad;
            ChangeConditions();
        }
        private void Start()
        {
            healthBar.SetMaxHealth(maxHitPoints);

            collider = GetComponent<CapsuleCollider>();
            animator = GetComponent<Animator>();
            isReady = true;
            StartCoroutine(SpawnPosition());
        }
        private void Update()
        {
            if (isAlive)
            {
                MovingPermanently();
            }
        }
        private void MovingPermanently()
        {
            if (isAlive)
            {
                animator.SetBool("isRunning", true);
                transform.Translate(0, 0, speed * Time.deltaTime);

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.SphereCast(ray, 2, out hit))
                {
                    if (hit.distance < obstacleRange)
                    {
                        StartCoroutine(IdlePosition());
                    }
                }
            }
        }
        public void TakeDamage(int damage)
        {
            currentHitPoints -= damage;
            healthBar.SetHealth(currentHitPoints);
            if (currentHitPoints <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            Destroy(collider);
            collider.enabled = false;
            isAlive = false;
            animator.SetBool("isDead", true);
            Removed();
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            Destroy(gameObject, 2.5f);
        }
        private void RotateProcess()
        {
            float angle = Random.Range(-130, 130);

            transform.Rotate(0, angle, 0);
        }
        IEnumerator IdlePosition()
        {
            animator.SetBool("isRunning", false);
            isAlive = false;
            yield return new WaitForSeconds(1f);
            RotateProcess();
            isAlive = true;
        }
        IEnumerator SpawnPosition()
        {
            collider.enabled = false;
            while (isReady)
            {
                isAlive = false;
                yield return new WaitForSeconds(2f);
                animator.SetBool("isReady", true);
                collider.enabled = true;
                isReady = false;
                isAlive = true;
            }
        }
        public void ChangeConditions()
        {
            if (gameTimeCount >= 18f)
            {
                speed += 2;
                maxHitPoints += 2;
            }
            if (gameTimeCount >= 33)
            {
                speed += 4;
                maxHitPoints += 4;
            }
            currentHitPoints = maxHitPoints;
        }
    }
}
