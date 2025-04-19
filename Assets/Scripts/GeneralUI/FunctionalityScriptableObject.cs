using UnityEngine;

[CreateAssetMenu(fileName = "New Functionality", menuName = "Funtionality/Create New Functionality")]
public class FunctionalityScriptableObject : ScriptableObject
{
    public int ID;
    public Texture2D functionalityIcon;
    public string functionalityName;
    public string functionalityDescription;
}
