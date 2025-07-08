using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public bool goUp;
    public static bool StarLevelUP;

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
        if (other.tag == "Player")
        {
            goUp = true;
            FindObjectOfType<AudioManager>().PlaySound("PickUpItem");

            if(UpgradeManager.StarLevel < 5)
            {
                UpgradeManager.StarLevel += 1;
            }
            StarLevelUP = true;

            Destroy(gameObject, 3f);
        }
    }
}
