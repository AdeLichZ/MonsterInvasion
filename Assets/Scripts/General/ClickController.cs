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
                    EnemyHealth enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
                    if (enemy)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
            }
        }
    }
}
