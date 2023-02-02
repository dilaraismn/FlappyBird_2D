using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float force;
    [SerializeField] private float tilt;
    [SerializeField] private Sprite[] birdImages;
    private int birdImageIndex;
    private Vector3 direction;
    private Image birdImage;
    public static bool isPause;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        birdImage = GetComponent<Image>();
    }

    private void Start()
    {

        InvokeRepeating(nameof(AnimateBirdImage), 0.2f, 0.2f);
    }

    private void Update()
    {
        if (!UIManager.isGameStarted) return;
       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up * force;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction;
        
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            
        }

        if (other.CompareTag("Score"))
        {
            
        }
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
