using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Animator anim;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        anim=this.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void OpenDoor()
    {
        anim.SetBool("isOpen", true);
        StartCoroutine(CloseDoor());
    }
    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("isOpen", false);
    }
}
