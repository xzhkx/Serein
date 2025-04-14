using UnityEngine;

public class ColoredStoneContact : MonoBehaviour
{
    [SerializeField]
    private char stoneID;

    private Puzzle_BridgeMemory bridgeMemory;
    private GameObject emission;
    private void Awake()
    {
        emission = transform.GetChild(0).gameObject;
        emission.SetActive(false);

        bridgeMemory = transform.parent.GetComponent<Puzzle_BridgeMemory>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        emission.SetActive(true);
        bridgeMemory.AddPasswordID(stoneID);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        emission.SetActive(false);
    }
}
