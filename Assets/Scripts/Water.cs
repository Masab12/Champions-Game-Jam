using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private GameObject _particles;

    private void Start() 
    {
        // Instantiate particles at the water's position
        Vector3 spawnPosition = transform.position; 
        Instantiate(_particles, spawnPosition, Quaternion.identity);
    }
}
