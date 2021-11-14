using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health;

    [HideInInspector] public bool canTakeKnockback = true;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void IDamageable.TakeDamage(float dmg)
    {
        health -= dmg;

        //check if dead
        if (health <= 0) Die();

        //apply knockback
        rb.AddForce((Vector2.up * 5) + (Vector2.right * 5), ForceMode2D.Impulse);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
