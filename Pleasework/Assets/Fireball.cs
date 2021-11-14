using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") return;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.1f);
            Destroy(this.gameObject);
    }
}
