using UnityEngine;

public class WoodPlankStep : MonoBehaviour
{
    [SerializeField]
    private GameObject nextWoodPlank;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            nextWoodPlank.SetActive(true);
        }
    }
}
