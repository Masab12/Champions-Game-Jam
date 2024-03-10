using UnityEngine;

public class Explosion: MonoBehaviour
{
    [SerializeField] private float blastRadius = 2f; 
    [SerializeField] private float blastForce = 500f;
    [SerializeField] private GameObject explosionParticles; 
    [SerializeField] private bool disableAfterExplosion = true; 

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Assuming your player has the "Player" tag
        {
            Explode(); 
            AudioManager.Instance.PlayExplosionSound();
            if (disableAfterExplosion) 
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Explode()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in nearbyObjects)
        {
            if (nearbyObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(blastForce, transform.position, blastRadius);
            }

            if (nearbyObject.gameObject.CompareTag("Player"))
            {
                Destroy(nearbyObject.gameObject); // Destroy the player
            }
        } 

        if (explosionParticles) 
        {
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
        }
}
}