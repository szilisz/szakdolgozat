using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    //[SerializeField] private AudioClip fire;

    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        //SoundManager.instance.PlaySound(fire);
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    new private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
            Deactivate();
        if (collision.tag != "Projectile")
        {
            hit = true;
            base.OnTriggerEnter2D(collision); //Execute logic from parent script first
            coll.enabled = false;
        }

        if (anim != null)
            anim.SetTrigger("explode"); //When the object is venom explode it
        else
            gameObject.SetActive(false); //When this hits any object deactivate
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}