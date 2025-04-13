using System.Collections.Generic;
using UnityEngine;

public class Puzzle_BridgeMemory : MonoBehaviour
{
    [SerializeField] private string password;
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
        if (currentPassword[0] == stoneID)
        {
            currentPassword.Remove(stoneID);
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
