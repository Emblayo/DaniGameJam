using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private float health = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Chaser":
                Die();
                break;
            case "Enemy":
                TakeDamage();
                break;
        }
    }

    void TakeDamage()
    {
        Debug.Log("DAMAGE TAKEN");
    }

    void Die()
    {
        Debug.Log("I DIED!");
    }
}
