using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack
{
    private EnemyAnimatorControl enemyAnimatorControl;
    private float attackDamage;

    public EnemyAttack(EnemyAnimatorControl enemyAnimatorControl, float attackDamage)
    {
        this.enemyAnimatorControl = enemyAnimatorControl;
        this.attackDamage = attackDamage;
    }

    public void AttackPlayer()
    {
        enemyAnimatorControl.SetTrigger("AttackTrigger");
    }
}
