using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using General;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] EnemyAI normalEnemyPrefab;
        [SerializeField] EnemyAI bigEnemyPrefab;
        [SerializeField] EnemyAI smallEnemyPrefab;

        [SerializeField] GameObject groundPrefab;

        private int interval = 2;                 // TO DO random interval     
        [SerializeField] float xLength, zLength;
        float xDistance, zDistance;

        public static event Action Added;
        void Awake()
        {
            //вычисление области спауна врагов
            xLength = groundPrefab.transform.localScale.x - 4;
            zLength = groundPrefab.transform.localScale.z - 4;
        }
        void Start()
        {
            StartCoroutine(MonsterSpawnCycle());
        }
        private IEnumerator MonsterSpawnCycle()
        {
            yield return new WaitForSeconds(TimeController.instance.countdownTime);
            while (true)
            {
                int randomEnemy = Random.Range(1, 4);
                if (randomEnemy == 1)
                {
                    MonsterAppear(smallEnemyPrefab);
                }
                else if (randomEnemy == 2)
                {
                    MonsterAppear(normalEnemyPrefab);
                }
                else if (randomEnemy == 3)
                {
                    MonsterAppear(bigEnemyPrefab);
                }
                yield return new WaitForSeconds(interval);
            }
        }

        private void MonsterAppear(EnemyAI enemyPrefab)
        {
            Vector3 randomPos = Vector3.zero;

            xDistance = Random.Range(-xLength / 2, xLength / 2);
            zDistance = Random.Range(-zLength / 2, zLength / 2);

            randomPos = new Vector3(xDistance, 1f, zDistance);
            Instantiate(enemyPrefab, randomPos, Quaternion.Euler(0, Random.Range(0, 360), 0));
            Added();
        }
    }
}
