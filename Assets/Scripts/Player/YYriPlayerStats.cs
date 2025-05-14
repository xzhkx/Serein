using System.Collections.Generic;
using UnityEngine;

public class YYriPlayerStats : MonoBehaviour, IDamagable
{
    [SerializeField]
    private List<CharacterStatsScriptableIObject> yyriStatsScriptable = 
        new List<CharacterStatsScriptableIObject>();

    private Animator yyriAnimator;

    private int currentLevel = 0;

    PlayerStats yyriStats;

    private void Awake()
    {
        yyriAnimator = GetComponent<Animator>();
        yyriStats = new PlayerStats(yyriStatsScriptable[currentLevel]);
    }

    public void LevelUp()
    {
        currentLevel++;
        yyriStats.LevelUp(yyriStatsScriptable[currentLevel]);
    }

    public void TakeDamage(int damage)
    {
        if (!yyriStats.TakeDamage(damage)) {
            Die();
        } else
        {
            yyriAnimator.SetTrigger("TakeDamage");
        }
    }

    private void Die()
    {
        yyriAnimator.Play("Die");
    }
}
