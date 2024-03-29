using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startUI, inGameUI, pauseUI;
    public static bool isGameStarted;
    private Player player;

    private void Awake()
    {
        //Application.targetFrameRate = 60;
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        player.enabled = false;
        isGameStarted = false;
        startUI.SetActive(true);
    }
    

    public void Button_StartGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
        isGameStarted = true;
        startUI.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void Button_Continue()
    {
        Player.isPause = false;
    }

    public void Button_Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
