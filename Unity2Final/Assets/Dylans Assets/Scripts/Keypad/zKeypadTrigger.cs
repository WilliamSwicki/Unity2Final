using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zKeypadTrigger : MonoBehaviour
{

    public GameObject keypadUI;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keypadUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Locked;
            keypadUI.SetActive(false);
        }
    }
}
