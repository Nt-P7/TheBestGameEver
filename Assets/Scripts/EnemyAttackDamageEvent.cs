using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamageEvent : MonoBehaviour
{
    public NewBehaviourScript enemyAI;
    public void AttackDamageEvent()
    {
        enemyAI.AttackDamage();
    }

}
