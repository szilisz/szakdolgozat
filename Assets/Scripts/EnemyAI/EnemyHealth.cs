using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Behaviour[] components;
    //[SerializeField] private AudioClip death;


    public float currentHealth { get; private set; }
    private Animator anim;
    public bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth == 0)
        {
                //SoundManager.instance.PlaySound(death);
                anim.SetTrigger("die");
                foreach (Behaviour component in components)
                    component.enabled = false;
                dead = true;

        }
    }
    private void DeactivateE()
    {
        gameObject.SetActive(false);
    }  
}
