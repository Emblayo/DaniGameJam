using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    public float AttackSpeed;
    private float currTime;

    public GameObject fireBall;
    public float fireBallSpeed;

    private void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > AttackSpeed)
        {
            Attack();
            currTime = 0;
        }
    }

    void Attack()
    {
        GameObject fireBallInstance = (GameObject)Instantiate(fireBall, new Vector2(transform.position.x - .4f, transform.position.y + .2f), transform.rotation);

        fireBallInstance.GetComponent<Rigidbody2D>().velocity = Vector2.left * fireBallSpeed;
    }
}
