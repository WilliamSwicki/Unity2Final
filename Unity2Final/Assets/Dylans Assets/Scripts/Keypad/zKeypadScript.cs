using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class zKeypadScript : MonoBehaviour
{

    public string password;
    public string enteredPW;

    public TMP_Text keypadDisplay;

    public int passDigits;
    //public GameObject escapePod;
    //public GameObject escapePodStand;

    public Camera cutsceneCamera;
    public Camera playerCamera;

    public GameObject keypadUI;


    void Start()
    {
        passDigits = password.Length;
        keypadDisplay.text = "Enter Code";
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }

        if(enteredPW.Length > 4)
        {
            KeypadDisplayCLEAR();
        }

        if(enteredPW.Length == passDigits)
        {
            if(enteredPW == password)
            {
                keypadDisplay.text = "CORRECT";
                //make the cutscene happen here
                playerCamera.enabled = false;
                cutsceneCamera.enabled = true;

                //Destroy(escapePodStand);
                //escapePod.GetComponent<BoxCollider>().enabled = false;//launch

                keypadUI.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                
                keypadDisplay.text = "ERROR";
                enteredPW = "";

            }
        }
    }
    public void KeypadDisplayCLEAR()
    {
        enteredPW = "";
        keypadDisplay.text = "";
    }

    public void ButtonNumber(string btnNumber)
    {
        EnterCode(btnNumber);
    }

    public void EnterCode(string keyEntered)
    {
        enteredPW += keyEntered;
        keypadDisplay.text = enteredPW;
    }
}
