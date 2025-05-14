public class PlayerStats 
{
    private int soulLevel;
    private int hp;
    private int attack;
    private int def;

    public PlayerStats(CharacterStatsScriptableIObject stats)
    {
        this.soulLevel = stats.soulLevel;
        this.hp = stats.hp;
        this.attack = stats.attack;
        this.def = stats.defense;
    }

    public void LevelUp(CharacterStatsScriptableIObject stats)
    {
        this.soulLevel = stats.soulLevel;
        this.hp = stats.hp;
        this.attack = stats.attack;
        this.def = stats.defense;
    }

    public bool TakeDamage(int damage) {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            return false;
        } else return true;
    }
}
