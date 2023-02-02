using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SceneEdge"))
        {
            Destroy(gameObject);
            print("ups");
        }
    }
}
