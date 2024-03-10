using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // Destroy immediately (assuming generic game objects)
        Destroy(collider.gameObject); 
    }
}