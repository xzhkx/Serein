public class Enemy
{
    private int health;
    private int damage;

    public Enemy(int health, int damage)
    {
        this.health = health;
        this.damage = damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public bool TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) { 
            health = 0;
            return false;
        } else return true;
    }
}
