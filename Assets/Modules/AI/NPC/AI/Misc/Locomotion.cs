using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    float actualVelocity;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        actualVelocity = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("Walk", actualVelocity);
    }
}
