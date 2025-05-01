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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
