using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float interval; // Інтервал часу між отриманням очок
    public int scoreToAdd;
    public int scoreToAddWithAc;


    void Start()
    {
        InvokeRepeating("AddScore", interval, interval);
    }
    void Update()
    {
    }
    private void AddScore()
    {
        if (!PlayerManager.isGameStarted)
            return;
        PlayerManager.score += (scoreToAdd + UpgradeManager.StarLevel);
        if(PlayerController.Dash == true)
        {
            PlayerManager.score += (scoreToAddWithAc + UpgradeManager.StarLevel);
        }
    }

}
