using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float Lifetimer;
    public float damage = 10;

    private void Start()
    {
        Invoke("DestroyFireball", Lifetimer);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.root.TryGetComponent(out EnemyHealth health))
        {
            health.DealDamage(damage);            
        }
        DestroyFireball();
    }


    private void DestroyFireball()
    {
        Destroy(gameObject);
    }      
}