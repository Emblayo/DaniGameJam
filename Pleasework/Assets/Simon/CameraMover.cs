using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
