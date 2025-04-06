using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create New Quest")]
public class QuestScriptableObject : ScriptableObject
{
    public string questName;
    public string questDescription;
}
