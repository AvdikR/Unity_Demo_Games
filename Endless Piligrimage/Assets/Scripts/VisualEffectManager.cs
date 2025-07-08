using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEffectManager : MonoBehaviour
{
    private int effectIndex;
    public static int number;

    public static int IsUnlocked1;
    public static int IsUnlocked2;
    public static int IsUnlocked3;
    public static int IsUnlocked4;
    public static int IsUnlocked5;
    public static int IsUnlocked6;
    public static int IsUnlocked7;
    public static int IsUnlocked8;
    public static int IsUnlocked9;

    public Button selectEffect1Button; 
    public Button selectEffect2Button; 
    public Button selectEffect3Button;
    public Button selectEffect4Button;
    public Button selectEffect5Button;
    public Button selectEffect6Button;
    public Button selectEffect7Button;
    public Button selectEffect8Button;
    public Button selectEffect9Button;

    public GameObject lockPanel1;
    public GameObject lockPanel2;
    public GameObject lockPanel3;
    public GameObject lockPanel4;
    public GameObject lockPanel5;
    public GameObject lockPanel6;
    public GameObject lockPanel7;
    public GameObject lockPanel8;
    public GameObject lockPanel9;

    public Button buyEffect1Button;
    public Button buyEffect2Button;
    public Button buyEffect3Button;
    public Button buyEffect4Button;
    public Button buyEffect5Button;
    public Button buyEffect6Button;
    public Button buyEffect7Button;
    public Button buyEffect8Button;
    public Button buyEffect9Button;

    void Start()
    {
        IsUnlocked1 = 1;
        number = 1;
        effectIndex = 0;

    }

    private void Update()
    {
        number = PlayerPrefs.GetInt("NumberEffect", 1);
        effectIndex = PlayerPrefs.GetInt("SelectedEffect", 0);

        IsUnlocked1 = PlayerPrefs.GetInt("UnlockedEffect1", 1);
        IsUnlocked2 = PlayerPrefs.GetInt("UnlockedEffect2", 0);
        IsUnlocked3 = PlayerPrefs.GetInt("UnlockedEffect3", 0);
        IsUnlocked4 = PlayerPrefs.GetInt("UnlockedEffect4", 0);
        IsUnlocked5 = PlayerPrefs.GetInt("UnlockedEffect5", 0);
        IsUnlocked6 = PlayerPrefs.GetInt("UnlockedEffect6", 0);
        IsUnlocked7 = PlayerPrefs.GetInt("UnlockedEffect7", 0);
        IsUnlocked8 = PlayerPrefs.GetInt("UnlockedEffect8", 0);
        IsUnlocked9 = PlayerPrefs.GetInt("UnlockedEffect9", 0);

        if (IsUnlocked1 == 1)
        {
            selectEffect1Button.gameObject.SetActive(true);
            buyEffect1Button.gameObject.SetActive(false);
            lockPanel1.SetActive(false);
        }
        if (IsUnlocked2 == 1)
        {
            selectEffect2Button.gameObject.SetActive(true);
            buyEffect2Button.gameObject.SetActive(false);
            lockPanel2.SetActive(false);
        }
        if (IsUnlocked3 == 1)
        {
            selectEffect3Button.gameObject.SetActive(true);
            buyEffect3Button.gameObject.SetActive(false);
            lockPanel3.SetActive(false);
        }
        if (IsUnlocked4 == 1)
        {
            selectEffect4Button.gameObject.SetActive(true);
            buyEffect4Button.gameObject.SetActive(false);
            lockPanel4.SetActive(false);
        }
        if (IsUnlocked5 == 1)
        {
            selectEffect5Button.gameObject.SetActive(true);
            buyEffect5Button.gameObject.SetActive(false);
            lockPanel5.SetActive(false);
        }
        if (IsUnlocked6 == 1)
        {
            selectEffect6Button.gameObject.SetActive(true);
            buyEffect6Button.gameObject.SetActive(false);
            lockPanel6.SetActive(false);
        }
        if (IsUnlocked7 == 1)
        {
            selectEffect7Button.gameObject.SetActive(true);
            buyEffect7Button.gameObject.SetActive(false);
            lockPanel7.SetActive(false);
        }
        if (IsUnlocked8 == 1)
        {
            selectEffect8Button.gameObject.SetActive(true);
            buyEffect8Button.gameObject.SetActive(false);
            lockPanel8.SetActive(false);
        }
        if (IsUnlocked9 == 1)
        {
            selectEffect9Button.gameObject.SetActive(true);
            buyEffect9Button.gameObject.SetActive(false);
            lockPanel9.SetActive(false);
        }

        if (effectIndex == 0)
        {
            selectEffect1Button.interactable = false;
        }
        if (effectIndex == 1)
        {
            selectEffect2Button.interactable = false;
        }
        if (effectIndex == 2)
        {
            selectEffect3Button.interactable = false;
        }
        if (effectIndex == 3)
        {
            selectEffect4Button.interactable = false;
        }
        if (effectIndex == 4)
        {
            selectEffect5Button.interactable = false;
        }
        if (effectIndex == 5)
        {
            selectEffect6Button.interactable = false;
        }
        if (effectIndex == 6)
        {
            selectEffect7Button.interactable = false;
        }
        if (effectIndex == 7)
        {
            selectEffect8Button.interactable = false;
        }
        if (effectIndex == 8)
        {
            selectEffect9Button.interactable = false;
        }


    }

    public void SelectNewEffect(int select)
    {
        int numberOfEffects = 9;

        //effectIndex++;

        if(effectIndex >= numberOfEffects)
        {
            effectIndex = 0;
        }

        DeselectAllButtons();

        switch (select)
        {
            case 0:
                selectEffect1Button.interactable = false;
                effectIndex = 0;
                number = 1;
                break;
            case 1:
                selectEffect2Button.interactable = false;
                effectIndex = 1;
                number = 2;
                break;
            case 2:
                selectEffect3Button.interactable = false;
                effectIndex = 2;
                number = 3;
                break;
            case 3:
                selectEffect4Button.interactable = false;
                effectIndex = 3;
                number = 4;
                break;
            case 4:
                selectEffect5Button.interactable = false;
                effectIndex = 4;
                number = 5;
                break;
            case 5:
                selectEffect6Button.interactable = false;
                effectIndex = 5;
                number = 6;
                break;
            case 6:
                selectEffect7Button.interactable = false;
                effectIndex = 6;
                number = 7;
                break;
            case 7:
                selectEffect8Button.interactable = false;
                effectIndex = 7;
                number = 8;
                break;
            case 8:
                selectEffect9Button.interactable = false;
                effectIndex = 8;
                number = 9;
                break;
        }

        PlayerPrefs.SetInt("SelectedEffect", effectIndex);
        PlayerPrefs.SetInt("NumberEffect", number);
    }

    private void DeselectAllButtons()
    {
        selectEffect1Button.interactable = true;
        selectEffect2Button.interactable = true;
        selectEffect3Button.interactable = true;
        selectEffect4Button.interactable = true;
        selectEffect5Button.interactable = true;
        selectEffect6Button.interactable = true;
        selectEffect7Button.interactable = true;
        selectEffect8Button.interactable = true;
        selectEffect9Button.interactable = true;

    }
}
