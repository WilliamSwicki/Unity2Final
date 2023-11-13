using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{

    public BaseRaycastFromPlyrCam raycastScript;
    [SerializeField] string objTagLookingFor;


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == (objTagLookingFor))
        {
            if(other.gameObject.name == "RedBox")
            {
                raycastScript.redBox = true;
            }
            if(other.gameObject.name == "BlueBox")
            {
                raycastScript.blueBox = true;
            }
            if (other.gameObject.name == "YellowBox")
            {
                raycastScript.yellowBox = true;
            }
            if (other.gameObject.name == "GreenBox")
            {
                raycastScript.greenBox = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == (objTagLookingFor))
        {
            if (other.gameObject.name == "RedBox")
            {
                raycastScript.redBox = false;
            }
            if (other.gameObject.name == "BlueBox")
            {
                raycastScript.blueBox = false;
            }
            if (other.gameObject.name == "YellowBox")
            {
                raycastScript.yellowBox = false;
            }
            if (other.gameObject.name == "GreenBox")
            {
                raycastScript.greenBox = false;
            }
        }
    }

}
