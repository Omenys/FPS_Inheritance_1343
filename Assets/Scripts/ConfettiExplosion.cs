using UnityEngine;

public class ConfettiExplosion : MonoBehaviour
{
    public ParticleSystem confetti;

    // Call particle system when projectile destroyed
    private void OnDestroy()
    {
        ExplodeConfetti(transform.position);

    }

    public void OnTriggerEnter(Collider other)
    {
        ExplodeConfetti(transform.position);
    }

    // Play particle system at position that projectile collides
    private void ExplodeConfetti(Vector3 position)
    {
        Instantiate(confetti, position, Quaternion.identity).Play();
    }
}
