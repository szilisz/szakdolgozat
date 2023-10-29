using UnityEngine;

public class EnemyDamageAI : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}