using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycastplayer : MonoBehaviour
{
    public float raycastDist = 5.0f;
    bool holdingItem = false;
    GameObject heldObj;
    public int greyPlate;

    public bool redBox = false;
    public bool blueBox = false;
    public bool greyBox = false;

    public GameObject doorButton;
    public GameObject[] numButton;
    public TMP_Text[] codeNum;
    public Animator leftDoor;
    public Animator rightDoor;
    bool doorUnlocked = false;
    public TMP_Text helpText;
    public AudioClip buttonBeep;

    MeshRenderer hitObj;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonBeep = doorButton.GetComponent<AudioSource>().clip;
        codeNum[0].enabled = false;
        codeNum[1].enabled = false;
        codeNum[2].enabled = false;
        codeNum[3].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * raycastDist, Color.green);
        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
        {
            if(hit.collider.CompareTag("PickupItem"))
            {
                helpText.enabled = true;
                helpText.text = $"Click to pickup";
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.05f);
            }
            else if(hit.collider.CompareTag("DoorButton") && doorUnlocked)
            {
                helpText.enabled = true;
                helpText.text = $"Press 'E'";
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.05f);
            }
            else if(hit.collider.CompareTag("numButtonUp") || hit.collider.CompareTag("numButtonDown"))
            {
                helpText.enabled = true;
                helpText.text = $"Press 'E'";
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.05f);
            }
            else
            {
                helpText.enabled = false;
                if(hitObj!= null)
                {
                    hitObj.materials[1].SetFloat("_Scale", 1.0f);
                    hitObj = null;
                }
            }
        }
        if(redBox&&blueBox)
        {
            doorButton.GetComponent<Renderer>().material.color = Color.green;
            doorUnlocked = true;
        }
        else
        {
            doorButton.GetComponent<Renderer>().material.color = Color.red;
            doorUnlocked = false;
        }
        if(greyBox)
        {
            switch(greyPlate)
            {
                case 0:
                    codeNum[0].enabled = true;
                    break;
                case 1:
                    codeNum[1].enabled = true;
                    break;
                case 2:
                    codeNum[2].enabled = true;
                    break;
                case 3:
                    codeNum[3].enabled = true;
                    break;
            }
        }
        else
        {
            codeNum[0].enabled = false;
            codeNum[1].enabled = false;
            codeNum[2].enabled = false;
            codeNum[3].enabled = false;
        }
    }

    public void PickupItem(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("PickupItem"))
                {
                    hit.collider.GetComponent<PickUpObj>().Pickup();
                    heldObj = hit.collider.gameObject;
                    holdingItem= true;
                }
            }
        }
        if(ctx.canceled)
        {
            if(holdingItem)
            {
                heldObj.GetComponent<PickUpObj>().Pickup();
                holdingItem = false;
                heldObj= null;
            }
        }
    }

    public void InteractableObject(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
            {
                if (hit.collider.CompareTag("DoorButton") && doorUnlocked)
                {
                    leftDoor.SetTrigger("OpenDoor");
                    rightDoor.SetTrigger("OpenDoor");
                    doorButton.GetComponent<AudioSource>().PlayOneShot(buttonBeep, 0.25f);
                }
                if(hit.collider.CompareTag("numButtonUp"))
                {
                    switch(hit.collider.name)
                    {
                        case "codeButtonUp1":
                            numButton[0].GetComponent<CodeButton>().upHit = true;
                            numButton[0].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonUp2":
                            numButton[1].GetComponent<CodeButton>().upHit = true;
                            numButton[1].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonUp3":
                            numButton[2].GetComponent<CodeButton>().upHit = true;
                            numButton[2].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonUp4":
                            numButton[3].GetComponent<CodeButton>().upHit = true;
                            numButton[3].GetComponent<CodeButton>().ChangeNum();
                            break;
                    }  
                }
                if (hit.collider.CompareTag("numButtonDown"))
                {
                    switch(hit.collider.name)
                    {
                        case "codeButtonDown1":
                            numButton[0].GetComponent<CodeButton>().downHit = true;
                            numButton[0].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonDown2":
                            numButton[1].GetComponent<CodeButton>().downHit = true;
                            numButton[1].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonDown3":
                            numButton[2].GetComponent<CodeButton>().downHit = true;
                            numButton[2].GetComponent<CodeButton>().ChangeNum();
                            break;
                        case "codeButtonDown4":
                            numButton[3].GetComponent<CodeButton>().downHit = true;
                            numButton[3].GetComponent<CodeButton>().ChangeNum();
                            break;
                    }
                }
            }
        }
    }
}
