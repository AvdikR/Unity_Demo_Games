using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool goUp;

    public static bool CoinMultiplier;

    void Update()
    {
        if (goUp == true)
        {
            transform.Rotate(0, 0, 0);
            transform.Translate(0, 0.03f, 0);
        }
        else
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            goUp = true;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");

            PlayerManager.numberOfCoins += 1;
            if(CoinMultiplier == true)
            {
                PlayerManager.numberOfCoins += (2 + UpgradeManager.CoinMultiplierUP);
                new WaitForSeconds(8);
                CoinMultiplier = false;
            }

            Destroy(gameObject, 0.3f);
        }
    }
}
