using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace General
{
    public class ClickController : MonoBehaviour
    {
        private new Camera camera;
        [SerializeField] GameObject monsterbBlood;
        [SerializeField] int damage = 1;

        void Start()
        {
            camera = GetComponent<Camera>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    EnemyAI enemy = hit.collider.gameObject.GetComponent<EnemyAI>();
                    if (enemy)
                    {
                        GameObject impact = Instantiate(monsterbBlood, hit.point, Quaternion.identity);
                        Destroy(impact, 0.5f);
                        enemy.TakeDamage(damage);
                        FindObjectOfType<AudioManager>().Play("Shot");
                    }
                    else
                    {                     
                        FindObjectOfType<AudioManager>().Play("MissClick");
                    }
                }
            }
        }
    }
}
