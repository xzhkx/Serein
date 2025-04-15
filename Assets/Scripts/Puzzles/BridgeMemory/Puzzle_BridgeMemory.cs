using System.Collections.Generic;
using UnityEngine;

public class Puzzle_BridgeMemory : MonoBehaviour
{
    [SerializeField] 
    private string password;

    [SerializeField]
    private GameObject bridgeWoodPlank;

    private List<char> currentPassword = new List<char>(4);

    private void Awake()
    {
        for (int i = 0; i < password.Length; i++) 
        {
            currentPassword.Add(password[i]);
        }
    }

    public void AddPasswordID(char stoneID)
    {
        if (currentPassword.Count <= 0) return;

        if (currentPassword[0] == stoneID)
        {
            currentPassword.Remove(stoneID);
            if (currentPassword.Count == 0)
            {
                bridgeWoodPlank.SetActive(true);
            }
        }
        else
        {
            currentPassword.Clear();
            for (int i = 0; i < password.Length; i++)
            {
                currentPassword.Add(password[i]);
            }
        }
    }
}
