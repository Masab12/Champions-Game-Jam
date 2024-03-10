using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public EnemySpawnerController controller;
    bool isZombieAlive;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isZombieAlive = true;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isZombieAlive == true)
        {
            animator.SetTrigger("Attack");
            isZombieAlive = false;
            controller.ZombieAttackTheCops(cop: collision.gameObject, zombie: gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            controller.ZombieGotShoot(gameObject);
            Destroy(other.gameObject);
        }
    }
}
