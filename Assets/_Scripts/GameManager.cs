using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private Player player;
    private PipeSpawner spawner;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<PipeSpawner>();

        Pause();
    }

    private void Play()
    {
        score = 0;
    }

    private void Pause()
    {
        
    }
    public void IncreaseScore()
    {
        print("increase score");
    }

    public void GameOver()
    {
        score++;
        print("game over");
    }
}
