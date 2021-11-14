using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    int Points;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);

        PlayerMovement controller = other.GetComponent<PlayerMovement>();

        if (controller != null)
        {
            Destroy(gameObject);
        }
    }
}
