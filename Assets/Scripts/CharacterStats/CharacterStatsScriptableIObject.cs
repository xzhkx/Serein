using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats/Create New Stats")]
public class CharacterStatsScriptableIObject : ScriptableObject
{
    public int soulLevel;
    public int attack;
    public int defense;
    public int hp;
    public int materialID;
    public Texture2D materialIcon;
    public int materialQuantity;
}
