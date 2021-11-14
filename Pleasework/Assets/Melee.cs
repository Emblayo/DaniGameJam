using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    bool canAttack = true;

    public Transform hitbox;
    private Animator anim;
    private PlayerMovement playerMovement;

    public float damage;
    public float attackDuration;
    public float stunDuration;


    [SerializeField] private LayerMask ignorePlayer;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = playerMovement.anim;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canAttack) return;
            StartCoroutine(Attack());
            StartCoroutine(StunDuration());

            anim.SetTrigger("Attack");

            var hit = Physics2D.OverlapBox(hitbox.position, hitbox.localScale / 2, 0, ~ignorePlayer);

            if (hit != null) DealDamage(hit);
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDuration);
        canAttack = true;
    }

    IEnumerator StunDuration()
    {
        playerMovement.canMove = false;
        yield return new WaitForSeconds(stunDuration);
        playerMovement.canMove = true;
    }

    private void DealDamage(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.tag == "Enemy") other.GetComponent<IDamageable>().TakeDamage(damage);
    }
}
