using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public string effectName;
    public int index;
    public int price;
    
    void Update()
    {
        /*
        int isUnlocked = PlayerPrefs.GetInt(effectName, 0);//0:false , 1:true
        if (isUnlocked == 0)
        {
            gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Coins", 0) < price)
                GetComponent<Button>().interactable = false;
            else
                GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.SetActive(false);
            
            if(PlayerPrefs.GetInt("SelectedCharacter", 0) == index)
            {
                selectEffectButton.gameObject.SetActive(true);
            }

        }*/
            
    }

    public void Unlock()
    {
        if (PlayerPrefs.GetInt("Coins", 0) < price)
            return;

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - price);
        FindObjectOfType<AudioManager>().PlaySound("BuyButton");
        /*
        PlayerPrefs.SetInt(effectName, 1);
        PlayerPrefs.SetInt("SelectedCharacter", index);
        */
        if (index == 0)
        {
            VisualEffectManager.IsUnlocked1 = 1;
            PlayerPrefs.SetInt("UnlockedEffect1", VisualEffectManager.IsUnlocked1);
        }
        if (index == 1)
        {
            VisualEffectManager.IsUnlocked2 = 1;
            PlayerPrefs.SetInt("UnlockedEffect2", VisualEffectManager.IsUnlocked2);
        }
        if (index == 2)
        {
            VisualEffectManager.IsUnlocked3 = 1;
            PlayerPrefs.SetInt("UnlockedEffect3", VisualEffectManager.IsUnlocked3);
        }
        if (index == 3)
        {
            VisualEffectManager.IsUnlocked4 = 1;
            PlayerPrefs.SetInt("UnlockedEffect4", VisualEffectManager.IsUnlocked4);
        }
        if (index == 4)
        {
            VisualEffectManager.IsUnlocked5 = 1;
            PlayerPrefs.SetInt("UnlockedEffect5", VisualEffectManager.IsUnlocked5);
        }
        if (index == 5)
        {
            VisualEffectManager.IsUnlocked6 = 1;
            PlayerPrefs.SetInt("UnlockedEffect6", VisualEffectManager.IsUnlocked6);
        }
        if (index == 6)
        {
            VisualEffectManager.IsUnlocked7 = 1;
            PlayerPrefs.SetInt("UnlockedEffect7", VisualEffectManager.IsUnlocked7);
        }
        if (index == 7)
        {
            VisualEffectManager.IsUnlocked8 = 1;
            PlayerPrefs.SetInt("UnlockedEffect8", VisualEffectManager.IsUnlocked8);
        }
        if (index == 8)
        {
            VisualEffectManager.IsUnlocked9 = 1;
            PlayerPrefs.SetInt("UnlockedEffect9", VisualEffectManager.IsUnlocked9);
        }

        /*
        lockPanel.gameObject.SetActive(false);
        selectEffectButton.gameObject.SetActive(true);*/
    }
}
