using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BaseRaycastFromPlyrCam : MonoBehaviour
{

    [SerializeField] float dist = 2.5f;
    bool holdingItem = false;
    GameObject heldObj;


    public bool redBox = false;
    public bool blueBox = false;
    public bool greenBox = false;
    public bool yellowBox = false;

    [SerializeField] GameObject doorButton;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip buttonSoundError;

    [SerializeField] AudioClip interactSound;

    public Animator leftDoor;
    public Animator rightDoor;

    bool doorUnlocked = false;

    MeshRenderer hitObj;
    [SerializeField] GameObject messageBox;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * dist, Color.green);

        if (redBox && blueBox && yellowBox && greenBox)//if boxes placed in the proper plates then buttton goes green
        {
            doorButton.GetComponent<Renderer>().material.color = Color.green;
            doorUnlocked = true;
        }
        else
        {
            doorButton.GetComponent<Renderer>().material.color = Color.red;
            doorUnlocked = false;

        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, dist))
        {
            if(hit.collider.tag == "PickupItem" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
            }
            if(hit.collider.tag == "DoorButton" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
                messageBox.SetActive(true); 
            }
        }
        else
        {
            if (hitObj != null)
            {
                hitObj.materials[1].SetFloat("_Scale", 1.0f);
                hitObj = null;
                if(messageBox.activeSelf)
                {
                    messageBox.SetActive(false);
                }
            }

        }

    }

    public void PickUpItem(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, dist))
            {
                Debug.Log("Holding? -> " + hit.collider.name);

                if (hit.collider.CompareTag("PickupItem"))
                {
                    hit.collider.GetComponent<PickupObj>().Pickup();
                    GetComponent<AudioSource>().PlayOneShot(interactSound);
                    heldObj = hit.collider.gameObject; 
                    holdingItem = true;
                }


            }
        }
        if (ctx.canceled)
        {
            if(holdingItem)
            {
                heldObj.GetComponent<PickupObj>().Pickup();
                holdingItem = false;
                heldObj = null;
            }
        }
    }

    public void InteractableOBJ(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, dist))
            {
                if (hit.collider.CompareTag("DoorButton") && doorUnlocked)
                {
                    GetComponent<AudioSource>().PlayOneShot(buttonSound);
                    leftDoor.SetTrigger("OpenDoor");
                    rightDoor.SetTrigger("OpenDoor");
                }
                else if (hit.collider.CompareTag("DoorButton") && !doorUnlocked)
                {
                    GetComponent<AudioSource>().PlayOneShot(buttonSoundError);
                }


            }
        }
    }
}
