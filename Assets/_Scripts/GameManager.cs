using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

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
