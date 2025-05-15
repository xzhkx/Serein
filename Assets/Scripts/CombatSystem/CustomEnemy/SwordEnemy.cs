using UnityEngine;

public class SwordEnemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int thisHealth;

    [SerializeField]
    private int thisDamage;

    private Enemy swordEnemy;

    private void Awake()
    {
        swordEnemy = new Enemy(thisHealth, thisDamage);
    }

    public void TakeDamage(int damage)
    {
        if (!swordEnemy.TakeDamage(damage))
        {
            gameObject.SetActive(false);
            InventoryManager.Instance.AddItem(13, 1);
        }
        Debug.Log(swordEnemy.GetHealth());
    } 
}
