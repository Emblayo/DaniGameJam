using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health;

    [HideInInspector] public bool canTakeKnockback = true;
    public bool canTakeDamage = true;

    Rigidbody2D rb;

    public float knockback = 5;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void IDamageable.TakeDamage(float dmg)
    {
        Knockback();

        if (canTakeDamage)
        {
            health -= dmg;

            //check if dead
            if (health <= 0) Die();
        }
    }

    void Knockback()
    {
        //apply knockback
        rb.AddForce((Vector2.up * knockback) + (Vector2.right * knockback), ForceMode2D.Impulse);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
