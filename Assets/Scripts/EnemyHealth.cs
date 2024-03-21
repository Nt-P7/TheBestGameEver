using System;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public PlayerProgress playerProgress;
    public Exception exceptionPrefab;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<NewBehaviourScript>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
