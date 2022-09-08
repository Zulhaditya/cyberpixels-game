using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 2f;
    public float bulletDamage = 1f;
    public Rigidbody2D rb;
    public Animator anim;

    [SerializeField] private AudioClip bulletImpact;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(bulletImpact);
        anim.SetTrigger("explode");

        if (collision.gameObject.TryGetComponent<Health>(out Health enemyHealth))
        {
            enemyHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1);
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
