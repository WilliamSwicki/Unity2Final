using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public Raycastplayer Raycastplayer;
    public int greyPlate;
    [SerializeField]
    string objTag;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "RedBox")
            {
                Raycastplayer.redBox = true;
            }
            if (other.gameObject.name == "BlueBox")
            {
                Raycastplayer.blueBox = true;
            }
            if(other.gameObject.name == "GrayBox")
            {
                Raycastplayer.greyPlate=greyPlate;
                Raycastplayer.greyBox= true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "RedBox")
            {
                Raycastplayer.redBox = false;
            }
            if (other.gameObject.name == "BlueBox")
            {
                Raycastplayer.blueBox = false;
            }
            if (other.gameObject.name == "GrayBox")
            {
                Raycastplayer.greyPlate=-1;
                Raycastplayer.greyBox = false;
            }
        }
    }
}
