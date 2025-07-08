using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public bool status = false;
    public float TimeOfAction;
    public string Name;

    private bool goUp = false;

    void Update()
    {
        if (goUp == true)
        {
            transform.Rotate(0, 0, 0);
            transform.Translate(0, 0.03f, 0);
        }
        else
        {
            transform.Rotate(0, 20 * Time.deltaTime, 0);
        }
        //transform.Rotate(0, 25 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goUp = true;
            FindObjectOfType<AudioManager>().PlaySound("PickUpItem");
            StartCoroutine(BoostController());
            Destroy(gameObject, 15f);
        }
    }

    IEnumerator BoostController()
    {
        status = true;
        yield return new WaitForSeconds(TimeOfAction);
        status = false;
    }

}
