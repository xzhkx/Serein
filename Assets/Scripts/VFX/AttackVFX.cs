using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    [SerializeField] private GameObject attackParticleObject;
    private ParticleSystem attackParticleSystem;

    private void Awake()
    {
        attackParticleSystem = attackParticleObject.GetComponent<ParticleSystem>();
    }

    public void PlayAttackVFX(Vector3 targetPosition)
    {
        attackParticleObject.transform.position = targetPosition;
        attackParticleSystem.Play();
    }
}
