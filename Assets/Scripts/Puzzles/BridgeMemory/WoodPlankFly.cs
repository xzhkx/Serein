using UnityEngine;

public class WoodPlankFly : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position + new Vector3(0, 19.5f, 0);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.07f);
    }
}
