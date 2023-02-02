using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI, inGameUI, pauseUI;
    [SerializeField] private TMP_Text scoreInGameText, scoreGameOverText, highScoreText;
    [SerializeField] private float gravity;
    [SerializeField] private float force;
    [SerializeField] private float tilt;
    [SerializeField] private Sprite[] birdImages;
    private int birdImageIndex;
    private Vector3 direction;
    private Image birdImage;
    private int score;
    public static bool isPause, isGameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        birdImage = GetComponent<Image>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        score = 0;
        isGameOver = false;
        InvokeRepeating(nameof(AnimateBirdImage), 0.2f, 0.2f);
    }

    private void Update()
    {
        if (!UIManager.isGameStarted || isGameOver || isPause) return;

        scoreInGameText.text = score.ToString();

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
        
        if (isPause)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
            inGameUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt ("HighScore", score);
                PlayerPrefs.Save();
            }

            Time.timeScale = 0;
            isGameOver = true;
            inGameUI.SetActive(false);
            gameOverUI.SetActive(true);
            scoreGameOverText.text = score.ToString();
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        if (other.CompareTag("Score"))
        {
            score++;
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
