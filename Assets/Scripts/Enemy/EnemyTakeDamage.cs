using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private float stunnedTime;

    private float currentStunnedTime;
    private EnemyAnimatorControl enemyAnimatorControl;
    private Rigidbody enemyRigidbody;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        currentStunnedTime = 0;
        enemyAnimatorControl = GetComponent<EnemyAnimatorControl>();
    }

    public void TakeDamage(int damage)
    {
        currentStunnedTime = stunnedTime;
        enemyHealth -= damage;
        enemyAnimatorControl.SetTrigger("DefendTrigger");
        if(enemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    public bool IsStunnedByAttack()
    {
        if (currentStunnedTime > 0)
        {
            enemyRigidbody.velocity = new Vector3(0, enemyRigidbody.velocity.y, 0);
            currentStunnedTime -= Time.deltaTime;
            return true;
        } else
        {
            return false;
        }
    }
    private void EnemyDie()
    {

    }
}
