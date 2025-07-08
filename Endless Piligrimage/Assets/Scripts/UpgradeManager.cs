using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Upgrade[] upgrades;

    public Text Upgrade1LevelText;
    public Text Upgrade2LevelText;
    public Text Upgrade3LevelText;
    public Text Upgrade4LevelText;
    public Text Upgrade5LevelText;

    public Slider upgradeSlider1;
    public Slider upgradeSlider2;
    public Slider upgradeSlider3;
    public Slider upgradeSlider4;
    public Slider upgradeSlider5;

    public Text upgradeLevelText1;
    public Text upgradeLevelText2;
    public Text upgradeLevelText3;
    public Text upgradeLevelText4;
    public Text upgradeLevelText5;

    static public int HealthUP;
    static public float DashTimeUP;
    static public int CoinMultiplierUP;
    static public int RecoveryUP;
    static public int MaxSpeedUP;

    static public int StarLevel;
    public Text StarLevelText;
    
    void Start()
    {
        upgrades[0].priceText.text = "" + upgrades[0].priceLevel2;
        upgrades[1].priceText.text = "" + upgrades[1].priceLevel2;
        upgrades[2].priceText.text = "" + upgrades[2].priceLevel2;
        upgrades[3].priceText.text = "" + upgrades[3].priceLevel2;
        upgrades[4].priceText.text = "" + upgrades[4].priceLevel2;

        StarLevel = PlayerPrefs.GetInt("StarLevel", 0);
    }

    void Update()
    {
        
        if (Star.StarLevelUP == true)
        {
            StarLevelSave();
        }

        if(StarLevel >= 5)
        {
            StarLevel = 5;
            StarLevelText.text = "5";
        }

        StarLevel = PlayerPrefs.GetInt("StarLevel", 0);
        StarLevelText.text = "" + StarLevel;

        upgrades[0].Level = PlayerPrefs.GetInt("Upgrade1Level", 1);
        upgrades[1].Level = PlayerPrefs.GetInt("Upgrade2Level", 1);
        upgrades[2].Level = PlayerPrefs.GetInt("Upgrade3Level", 1);
        upgrades[3].Level = PlayerPrefs.GetInt("Upgrade4Level", 1);
        upgrades[4].Level = PlayerPrefs.GetInt("Upgrade5Level", 1);

        upgrades[0].priceText.text = PlayerPrefs.GetString("Upgrade1Price", upgrades[0].priceText.text);
        upgrades[1].priceText.text = PlayerPrefs.GetString("Upgrade2Price", upgrades[1].priceText.text);
        upgrades[2].priceText.text = PlayerPrefs.GetString("Upgrade3Price", upgrades[2].priceText.text);
        upgrades[3].priceText.text = PlayerPrefs.GetString("Upgrade4Price", upgrades[3].priceText.text);
        upgrades[4].priceText.text = PlayerPrefs.GetString("Upgrade5Price", upgrades[4].priceText.text);

        Upgrade1LevelText.text = "Health lv: " + upgrades[0].Level;
        Upgrade2LevelText.text = "Dash lv: " + upgrades[1].Level;
        Upgrade3LevelText.text = "Coin multiplier lv: " + upgrades[2].Level;
        Upgrade4LevelText.text = "Recovery lv: " + upgrades[3].Level;
        Upgrade5LevelText.text = "Max speed lv: " + upgrades[4].Level;

        upgradeSlider1.value = upgrades[0].Level;
        upgradeSlider2.value = upgrades[1].Level;
        upgradeSlider3.value = upgrades[2].Level;
        upgradeSlider4.value = upgrades[3].Level;
        upgradeSlider5.value = upgrades[4].Level;

        upgradeLevelText1.text = upgrades[0].Level + "/5";
        upgradeLevelText2.text = upgrades[1].Level + "/5";
        upgradeLevelText3.text = upgrades[2].Level + "/5";
        upgradeLevelText4.text = upgrades[3].Level + "/5";
        upgradeLevelText5.text = upgrades[4].Level + "/5";

        //Upgrade Health
        if (upgrades[0].Level == 1)
        {
            HealthUP = 0;
        }
        if (upgrades[0].Level == 2)
        {
            HealthUP = 20;
        }
        if (upgrades[0].Level == 3)
        {
            HealthUP = 40;
        }
        if (upgrades[0].Level == 4)
        {
            HealthUP = 60;
        }
        if (upgrades[0].Level == 5)
        {
            HealthUP = 80;
        }

        //Upgrade MaxSpeed
        if (upgrades[4].Level == 1)
        {
            MaxSpeedUP = 0;
        }
        if (upgrades[4].Level == 2)
        {
            MaxSpeedUP = 1;
        }
        if (upgrades[4].Level == 3)
        {
            MaxSpeedUP = 2;
        }
        if (upgrades[4].Level == 4)
        {
            MaxSpeedUP = 3;
        }
        if (upgrades[4].Level == 5)
        {
            MaxSpeedUP = 4;
        }

        //Upgrade Recovery
        if(upgrades[3].Level == 1)
        {
            RecoveryUP = 0;
        }
        if (upgrades[3].Level == 2)
        {
            RecoveryUP = 10;
        }
        if (upgrades[3].Level == 3)
        {
            RecoveryUP = 20;
        }
        if (upgrades[3].Level == 4)
        {
            RecoveryUP = 30;
        }
        if (upgrades[3].Level == 5)
        {
            RecoveryUP = 40;
        }

        //Upgrade CoinMultiplier
        if (upgrades[2].Level == 1)
        {
            CoinMultiplierUP = 0;
        }
        if (upgrades[2].Level == 2)
        {
            CoinMultiplierUP = 1;
        }
        if (upgrades[2].Level == 3)
        {
            CoinMultiplierUP = 2;
        }
        if (upgrades[2].Level == 4)
        {
            CoinMultiplierUP = 3;
        }
        if (upgrades[2].Level == 5)
        {
            CoinMultiplierUP = 4;
        }

        //Upgrade Dash
        if (upgrades[1].Level == 1)
        {
            DashTimeUP = 0;
        }
        if (upgrades[1].Level == 2)
        {
            DashTimeUP = 1;
        }
        if (upgrades[1].Level == 3)
        {
            DashTimeUP = 2;
        }
        if (upgrades[1].Level == 4)
        {
            DashTimeUP = 3;
        }
        if (upgrades[1].Level == 5)
        {
            DashTimeUP = 4;
        }

        if(upgrades[0].Level == 5 && upgrades[1].Level == 5 && upgrades[2].Level == 5 &&
            upgrades[3].Level == 5 && upgrades[4].Level == 5)
        {
            AchievementManager.TheBestPilgrim = true;
        }

    }

    public void UpgradeSkill(int upgradeIndex)
    {
        Upgrade upgrade = upgrades[upgradeIndex];
        upgrade.priceText.text = "" + upgrade.priceLevel2;

        int nextLevel = upgrade.Level + 1;
        if (nextLevel > 5) 
        {
            Debug.Log("Max level reached for " + upgrade.Name);
            return;
        }
        

        int price = 0;
        switch (nextLevel)
        {
            case 2:
                price = upgrade.priceLevel2;
                if (PlayerPrefs.GetInt("Coins", 0) < price || upgrade.priceText.text == "MAX")
                    return;

                upgrade.priceText.text = "" + upgrade.priceLevel3;
                break;
            case 3:
                price = upgrade.priceLevel3;
                if (PlayerPrefs.GetInt("Coins", 0) < price || upgrade.priceText.text == "MAX")
                    return;

                upgrade.priceText.text = "" + upgrade.priceLevel4;
                break;
            case 4:
                price = upgrade.priceLevel4;
                if (PlayerPrefs.GetInt("Coins", 0) < price || upgrade.priceText.text == "MAX")
                    return;

                upgrade.priceText.text = "" + upgrade.priceLevel5;
                break;
            case 5:
                price = upgrade.priceLevel5;
                if (PlayerPrefs.GetInt("Coins", 0) < price || upgrade.priceText.text == "MAX")
                    return;

                upgrade.priceText.text = "MAX";
                break;
        }
        
        if (PlayerPrefs.GetInt("Coins", 0) < price)
        {
            Debug.Log("Not enough coins to upgrade " + upgrade.Name);
            return;
        }

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - price);
        PlayerManager.numberOfCoins = PlayerManager.numberOfCoins - price;
        upgrade.Level = nextLevel;

        PlayerPrefs.SetInt("Upgrade1Level", upgrades[0].Level);
        PlayerPrefs.SetInt("Upgrade2Level", upgrades[1].Level);
        PlayerPrefs.SetInt("Upgrade3Level", upgrades[2].Level);
        PlayerPrefs.SetInt("Upgrade4Level", upgrades[3].Level);
        PlayerPrefs.SetInt("Upgrade5Level", upgrades[4].Level);
        
        PlayerPrefs.SetString("Upgrade1Price", upgrades[0].priceText.text);
        PlayerPrefs.SetString("Upgrade2Price", upgrades[1].priceText.text);
        PlayerPrefs.SetString("Upgrade3Price", upgrades[2].priceText.text);
        PlayerPrefs.SetString("Upgrade4Price", upgrades[3].priceText.text);
        PlayerPrefs.SetString("Upgrade5Price", upgrades[4].priceText.text);
        
        /*
        for (int i = 0; i < upgrades.Length; i++)
        {
            Upgrade u = upgrades[i];
            u.priceText.text = PlayerPrefs.GetInt("Upgrade" + (i + 1) + "Price", u.priceLevel2).ToString();
        }
        */

        //UpdateUpgradePriceText(upgradeIndex);

        // Оновіть тексти рівнів навичок
        //UpdateUpgradeTexts();
    }

    public void StarLevelSave()
    {
        PlayerPrefs.SetInt("StarLevel", StarLevel);
    }
    
}
