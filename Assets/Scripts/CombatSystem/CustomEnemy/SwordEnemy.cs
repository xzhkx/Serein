using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int damage;

    private void Awake()
    {
        Enemy swordEnemy = new Enemy(health, damage);

    }
}
