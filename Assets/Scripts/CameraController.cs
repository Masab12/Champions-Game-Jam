using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerToFollow; // Make this reference dynamic
    public Vector3 offset;
    public PlayerSpawning playerSpawning;

    void LateUpdate()
    {
        if (playerToFollow != null)  
        {
            transform.position = playerToFollow.transform.position + offset;
        } else if (playerSpawning != null && !playerSpawning.isGameOver) 
        {
            // If there are no active cops left, try to find one from the spawner
            GameObject cop = playerSpawning.getCop(0); // Get first cop, adjust index as needed
            if (cop != null) 
            {
                playerToFollow = cop;
            }
        }
    }
    }
