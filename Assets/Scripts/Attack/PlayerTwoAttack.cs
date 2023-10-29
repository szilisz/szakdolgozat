using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float shieldCooldown;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] public GameObject shield;

    //[SerializeField] private AudioClip fire;
    private Animator anim;
    private PlayerTwo playerMovement;
    private Health health;

    private float cooldownAttackTimer = Mathf.Infinity;
    private float cooldownShieldTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        playerMovement = GetComponent<PlayerTwo>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && cooldownAttackTimer > attackCooldown)
        {
           // SoundManager.instance.PlaySound(fire);
            Attack2();
        }

        cooldownAttackTimer += Time.deltaTime;
        cooldownShieldTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.DownArrow) && cooldownShieldTimer > shieldCooldown && playerMovement.isGrounded())
            Shield();

        if (cooldownShieldTimer > 2f)
        {
            shield.gameObject.SetActive(false);
        }

        if (health.currentHealth <= 0)
        {
            anim.SetTrigger("die");
            GetComponent<PlayerTwo>().enabled = false;
            GetComponent<PlayerTwoAttack>().enabled = false;

        }

    }
    private void Shield()
    {
        shield.gameObject.SetActive(true);
        cooldownShieldTimer = 0;
    }

    private void Attack2()
    {
        anim.SetTrigger("attack");
        cooldownAttackTimer = 0;

        fireballs[FindFire()].transform.position = firePoint.position;
        fireballs[FindFire()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFire()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}
