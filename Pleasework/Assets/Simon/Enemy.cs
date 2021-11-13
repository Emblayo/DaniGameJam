using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health;

    void IDamageable.TakeDamage(float dmg)
    {
        health -= dmg;

        //check if dead
        if (health <= 0) Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
