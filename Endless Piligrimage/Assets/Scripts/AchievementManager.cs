using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Toggle[] AchievementToggles;

    public static int ThePathIsPassed;
    public static bool TheBestPilgrim = false;
    public static int TheGoldenPath;
    public static int GoodPilgrimage1;
    public static int GoodPilgrimage2;
    public static int RisingStar;

    void Start()
    {
        CheckAchievements();
        ThePathIsPassed = PlayerPrefs.GetInt("HighScore", 0);
        TheGoldenPath = PlayerPrefs.GetInt("HighCoins", 0);
        RisingStar = PlayerPrefs.GetInt("StarLevel", 0);
    }

    void Update()
    {
        if(ThePathIsPassed >= 5000)
        {
            CheckAchievements();
        }
        if(TheBestPilgrim == true)
        {
            CheckAchievements();
        }
        if(TheGoldenPath >= 500)
        {
            CheckAchievements();
        }
        if(RisingStar >= 3)
        {
            CheckAchievements();
        }
        
    }

    void CheckAchievements()
    {
        foreach (Toggle toggle in AchievementToggles)
        {
            if (toggle.name == "Toggle1") 
            {
                if (ThePathIsPassed >= 5000)
                {
                    toggle.isOn = true; 
                }
                else
                {
                    toggle.isOn = false; 
                }
            }
            if(toggle.name == "Toggle2")
            {
                if(TheBestPilgrim == true)
                {
                    toggle.isOn = true;
                }
                else
                {
                    toggle.isOn = false;
                }
            }
            if(toggle.name == "Toggle3")
            {
                if(TheGoldenPath >= 500)
                {
                    toggle.isOn = true;
                }
                else
                {
                    toggle.isOn = false;
                }
            }
            if(toggle.name == "Toggle4")
            {
                if (RisingStar >= 3)
                {
                    toggle.isOn = true;
                }
                else
                {
                    toggle.isOn = false;
                }
            }
        }
    }
}
