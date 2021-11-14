using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private float health = 10;
    private float currentHealth = 10;


    public float knockback;
    [SerializeField] private float stunDuration;

    Rigidbody2D rb;

    private PlayerMovement playerMovement;

    Animator anim;

    private void Start()
    {
        currentHealth = health; 
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        anim = playerMovement.anim;
    }

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
        ApplyKnockback();
        currentHealth--;

        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }

    void ApplyKnockback()
    {
        StartCoroutine(KnockbackDuration());

        //play animation
        anim.SetTrigger("Hit");
    }

    IEnumerator KnockbackDuration()
    {
        playerMovement.canMove = false;
        rb.AddForce(new Vector3(-1, 1, 0) * knockback, ForceMode2D.Impulse);
        yield return new WaitForSeconds(stunDuration);
        playerMovement.canMove = true;
    }
}
