using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        if (UIManager.isGameStarted && !Player.isPause && !Player.isGameOver)
        {
            transform.position += Vector3.left * speed;

            if (transform.position.x < leftEdge)
            {
                Destroy(gameObject);
            }
        }
    }
}
