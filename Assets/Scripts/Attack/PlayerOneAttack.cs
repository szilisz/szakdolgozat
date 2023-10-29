using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float shieldCooldown;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] ice;
    [SerializeField] public GameObject shield;
   // public static bool isGameOver = false;

    private Animator anim;
    private PlayerOne playerMovement;
    private Health health;

    private float cooldownAttackTimer = Mathf.Infinity;
    private float cooldownShieldTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        playerMovement = GetComponent<PlayerOne>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownAttackTimer > attackCooldown)
        {
            Attack();
        }

        cooldownAttackTimer += Time.deltaTime;
        cooldownShieldTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S) && cooldownShieldTimer > shieldCooldown && playerMovement.isGrounded())
            Shield();

        if (cooldownShieldTimer > 2f)
        {
            shield.gameObject.SetActive(false);
        }

        if (health.currentHealth <= 0)
        {
            anim.SetTrigger("die");
            //isGameOver = true;
            GetComponent<PlayerOne>().enabled = false;
            GetComponent<PlayerOneAttack>().enabled = false;

        }

    }
    private void Shield()
    {
        shield.gameObject.SetActive(true);
        cooldownShieldTimer = 0;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownAttackTimer = 0;

        ice[FindIce()].transform.position = firePoint.position;
        ice[FindIce()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindIce()
    {
        for (int i = 0; i < ice.Length; i++)
        {
            if (!ice[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}
