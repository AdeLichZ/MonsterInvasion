using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WanderingAI : MonoBehaviour
{
    NavMeshAgent agent;
    private float obstacleRange = 2f;
    bool isAlive;
    public float speed = 5f;

    private void MovingPermanently()
    {
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

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
    }

    private void RotateProcess()
    {
        float angle = Random.Range(-110, 100);   // to do smooth rotate

        transform.Rotate(0, angle, 0);
    }
}
