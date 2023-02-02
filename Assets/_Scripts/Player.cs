using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float force;
    [SerializeField] private Sprite[] birdImages;
    private int birdImageIndex;
    private Vector3 direction;
    private Image birdImage;

    private void Awake()
    {
        birdImage = GetComponent<Image>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateBirdImage), 0.2f, 0.2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up * force;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction;
    }

    private void AnimateBirdImage()
    {
        birdImageIndex++;
        if (birdImageIndex >= birdImages.Length)
        {
            birdImageIndex = 0;
        }
        birdImage.sprite = birdImages[birdImageIndex];
    }
}
