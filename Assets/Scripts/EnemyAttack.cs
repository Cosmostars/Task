using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    PlayerHealth playerHealth;
    private GameObject player;
    private bool playerInRange = false;
    private bool canAttack = true;
    private Animator anim;
    private bool enemyProjectileState;
    public GameObject enemyProjectile;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyProjectileState = false;
    }

    private void Update()
    {
        if (playerInRange && canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (enemyProjectileState)
        {
            enemyProjectile.SetActive(true);
            anim.SetTrigger("EnemyAttack");
            playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            enemyProjectileState = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
