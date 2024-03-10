using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public PlayerController player;
    public ZombieSpawner spawner;
    public Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (spawner.isZombieAttack)
        {
            animator.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * 1f);
        }
        else 
        {
            animator.SetBool("isWalking", false);  // Stop Walk Animation
        }
        
    }
}
