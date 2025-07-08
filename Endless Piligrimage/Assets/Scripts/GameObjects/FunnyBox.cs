using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyBox : MonoBehaviour
{
    public bool destroy;
    public bool goUp;

    void Update()
    {
        if(destroy == true)
        {
            
        }

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
        if (other.tag == "Player")
        {
            goUp = true;
            FindObjectOfType<AudioManager>().PlaySound("PickUpItem");
            int randomIndex = Random.Range(0, 7);
            ApplyRandomFunction(randomIndex);
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject, 0.5f);
        }
    }

    private void ApplyRandomFunction(int index)
    {
        switch (index)
        {
            case 0:
                PlayerManager.numberOfCoins += 10;
                break;
            case 1:
                PlayerManager.numberOfCoins += 15;
                break;
            case 2:
                PlayerManager.numberOfCoins += 20;
                break;
            case 4:
                PlayerManager.numberOfCoins += 25;
                break;
            case 5:
                PlayerManager.currentHealth -= 10;
                break;
            case 6:
                PlayerManager.currentHealth -= 20;
                break;
            case 7:
                PlayerManager.currentHealth -= 30;
                break;

        }
    }
}
