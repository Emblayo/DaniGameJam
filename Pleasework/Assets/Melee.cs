using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    bool canAttack = true;

    public Transform hitbox; 

    public float damage;

    [SerializeField] private LayerMask ignorePlayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canAttack) return;
            StartCoroutine(Attack());

            var hit = Physics2D.OverlapBox(hitbox.position, hitbox.localScale / 2, 0, ~ignorePlayer);

            if (hit != null) DealDamage(hit);
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.1f);
        canAttack = true;
    }

    private void DealDamage(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.tag == "Enemy") other.GetComponent<IDamageable>().TakeDamage(damage);
    }
}
