using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject sword;
    public GameObject spear;
    public GameObject bomb;
    WeaponSwitch weaponSelected;
    [SerializeField] GameObject player;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = player.GetComponent<WeaponSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (weaponSelected.activeWeapon == sword)
        {
            animator.SetTrigger("Attack");
            attackDamage = 1;
        } else if (weaponSelected.activeWeapon ==spear)
        {
            animator.SetTrigger("Attack2");
            attackDamage = 4;
        } else if (weaponSelected.activeWeapon == bomb)
        {
            animator.SetTrigger("Attack3");
            attackDamage = 10;
        }
        
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
