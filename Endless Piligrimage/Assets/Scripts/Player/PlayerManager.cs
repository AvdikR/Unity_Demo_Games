using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static int MaxHealth = 100;
    public static int currentHealth;
    public Slider healthBar;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public static int highNumberOfCoins;
    public Text coinsText;

    public static int score;
    public Text scoreText;
    public Text EndJourneyScore;
    public Text NewRecordText;

    public static bool isGamePaused;

    public GameObject TopGamePanel;
    public GameObject StartedTopGamePanel;
    public GameObject LowerGamePanel;

    public Text highScoreText;
    public Text highCoinsText;

    public Text nowCoinsText;

    public static bool Recovery;
    public int RecoveryHealthAmount;

    private bool goDown = false;

    void Start()
    {
        Coin.CoinMultiplier = false;
        PlayerController.Dash = false;
        LowerGamePanel.SetActive(true);
        StartedTopGamePanel.SetActive(true);
        NewRecordText.enabled = false;
        currentHealth = MaxHealth + UpgradeManager.HealthUP;
        healthBar.maxValue = MaxHealth + UpgradeManager.HealthUP;
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        isGamePaused = false;
        score = 0;
        numberOfCoins = PlayerPrefs.GetInt("Coins", 0);
        //AdManager.instance.RequestInterstitial();
    }

    void Update()
    {
        PlayerPrefs.SetInt("Coins", numberOfCoins);

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0) + "m";
        highCoinsText.text = "High coins received: " + PlayerPrefs.GetInt("HighCoins", 0);
        nowCoinsText.text = coinsText.text = "" + PlayerPrefs.GetInt("Coins", 0);

        healthBar.value = currentHealth;
        
        if(Recovery == true)
        {
            //int health = 0;
            //health.Equals(currentHealth);
            //RecoveryUse();
            StartCoroutine(RecoveryTimer());
        }

        if (currentHealth <= 0)
        {
            gameOver = true; 
        }
        
        if (gameOver)
        {
            Time.timeScale = 0;
            
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                NewRecordText.enabled = true;
            }

            if (numberOfCoins > PlayerPrefs.GetInt("HighCoins", 0))
            {
                PlayerPrefs.SetInt("HighCoins", numberOfCoins);
            }

            EndJourneyScore.text = "Score: " + score + "m";
            gameOverPanel.SetActive(true);

            PlayerController.Dash = false;
            Recovery = false;
            Coin.CoinMultiplier = false;

            /*
            if(Random.Range(0, 5) == 0)
            {
                AdManager.instance.ShowInterstitial();
            }*/
        }

        scoreText.text = score + "m";

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (SwipeManager.tap && !isGameStarted)
        {
            goDown = true;
            isGameStarted = true;
            Destroy(startingText);
            StartCoroutine(DeactivateLowerGamePanel());
            TopGamePanel.SetActive(true);
            StartedTopGamePanel.SetActive(false);
        }

        if (goDown == true)
        {
            LowerGamePanel.transform.Translate(0, -5f, 0);
        }
    }
    private IEnumerator DeactivateLowerGamePanel()
    {
        yield return new WaitForSeconds(2.5f); // Затримка 2 секунди
        LowerGamePanel.SetActive(false);
    }

    void RecoveryUse()
    {
        int health = 0;
        health.Equals(currentHealth);
       
        if (currentHealth + UpgradeManager.HealthUP < UpgradeManager.HealthUP + MaxHealth)
        {
            if(currentHealth < health + 20 + UpgradeManager.RecoveryUP)
            {
                currentHealth += 1;
            }
            //currentHealth += 1;
            
            if (currentHealth >= health + 20 + UpgradeManager.RecoveryUP)
            {
                currentHealth += 0;
            }

            if (currentHealth > MaxHealth + UpgradeManager.HealthUP)
            {
                currentHealth = MaxHealth + UpgradeManager.HealthUP;
            }
        }
        new WaitForSeconds(5);
        health.Equals(0);
        Recovery = false;
    }

    IEnumerator RecoveryTimer()
    {
        /*
        int health = 0;
        health.Equals(currentHealth);*/
        int health = currentHealth;
        
        if (currentHealth + UpgradeManager.HealthUP < UpgradeManager.HealthUP + MaxHealth)
        {
            if (currentHealth < health + 20 + UpgradeManager.RecoveryUP)
            {
                currentHealth += 1;
            }
            
            if (currentHealth >= health + 20 + UpgradeManager.RecoveryUP)
            {
                currentHealth += 0;
            }

            if (currentHealth > MaxHealth + UpgradeManager.HealthUP)
            {
                currentHealth = MaxHealth + UpgradeManager.HealthUP;
            }
        }
        yield return new WaitForSeconds(5);
        health = 0;
        //health.Equals(0);
        Recovery = false;
    }
}

