using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeButton : MonoBehaviour
{
    public GameObject upButton;
    public GameObject downButton;
    public TMP_Text numText;
    public TMP_Text[] codeNum;
    public TMP_Text[] codeText;
    public bool numRight1 = false;
    public bool upHit = false;
    public bool downHit = false;
    public Animator anim;
    public AudioClip beep;

    public void Start()
    {
        
    }
    // Update is called once per frame 
    void Update()
    {
        if (codeNum[0].text == codeText[0].text)
        {
            codeNum[0].color = Color.green;
            gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 0.05f);
        }
        if(codeNum[1].text == codeText[1].text)
        {
            codeNum[1].color = Color.green;
            gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 0.05f);
        }
        if (codeNum[2].text == codeText[2].text)
        {
            codeNum[2].color = Color.green;
            gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 0.05f);
        }
        if (codeNum[3].text == codeText[3].text)
        {
            codeNum[3].color = Color.green;
            gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 0.05f);
        }
        if (codeNum[0].color == Color.green && codeNum[1].color == Color.green && codeNum[2].color == Color.green && codeNum[3].color == Color.green)
        {
            anim.SetTrigger("Open");
        }
    }
    public void ChangeNum()
    {
        if(upHit)
        {
            switch(numText.text)
            {
                case "0":
                    numText.text = "1";
                    break;
                case "1":
                    numText.text = "2"; 
                    break;
                case "2":
                    numText.text = "3";
                    break;
                case "3":
                    numText.text = "4";
                    break;
                case "4":
                    numText.text = "5";
                    break;
                case "5":
                    numText.text = "6";
                    break;
                case "6":
                    numText.text = "7";
                    break;
                case "7":
                    numText.text = "8";
                    break;
                case "8":
                    numText.text = "9";
                    break;
                case "9":
                    numText.text = "0";
                    break;
            }
            upHit= false;
        }
        if(downHit)
        {
            switch (numText.text)
            {
                case "0":
                    numText.text = "9";
                    break;
                case "1":
                    numText.text = "0";
                    break;
                case "2":
                    numText.text = "1";
                    break;
                case "3":
                    numText.text = "2";
                    break;
                case "4":
                    numText.text = "3";
                    break;
                case "5":
                    numText.text = "4";
                    break;
                case "6":
                    numText.text = "5";
                    break;
                case "7":
                    numText.text = "6";
                    break;
                case "8":
                    numText.text = "7";
                    break;
                case "9":
                    numText.text = "8";
                    break;
            }
            downHit= false;
        }
    }
}
