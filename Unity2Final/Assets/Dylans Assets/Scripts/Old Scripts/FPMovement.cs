using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Automatically adds character controller component to gameObject
[RequireComponent(typeof(CharacterController))]


public class FPMovement : MonoBehaviour
{
    public float speed = 10;
    float h, v;
    public float gravity = -9.81f;
    public float jumpStr = -9.0f;
    [SerializeField] float velocity;
    float gravityMultiplier = 3.0f;

    CharacterController controller;

    public Animator anim;

    public AudioClip hittingTheGround;
    public AudioClip boneCrack;

    bool isFalling = false;

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = h * speed;
        float moveZ = v * speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);

        movement = Vector3.ClampMagnitude(movement, speed);//never will go above speed

        if(!IsGrounded() && velocity < -12.0f)//negitive for when falling
        {
            isFalling = true;
        }

        if(IsGrounded() && velocity < 0.5f)
        {
            velocity = -1;

            if (isFalling == true)
            {
                anim.SetTrigger("shake");
                GetComponent<AudioSource>().PlayOneShot(boneCrack);
                GetComponent<AudioSource>().PlayOneShot(hittingTheGround);

            }
            isFalling = false;
        }
        else
        {
            
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        

        movement.y = velocity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);

       // Debug.Log("Ground? " + IsGrounded());
        
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        h = ctx.ReadValue<Vector2>().x;
        v = ctx.ReadValue<Vector2>().y;
    }

    bool IsGrounded()
    {
        return controller.isGrounded;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!IsGrounded())
        {
            return;
        }

        if(ctx.performed)
        {
            velocity *= jumpStr;
        }

    }

    
}
