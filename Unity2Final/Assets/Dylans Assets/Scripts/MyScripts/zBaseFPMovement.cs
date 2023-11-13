using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem;

//Automatically adds character controller component to gameObject
[RequireComponent(typeof(CharacterController))]


public class zBaseFPMovement : MonoBehaviour
{
    public float speed = 8;
    float h, v;
    public float gravity = -9.81f;
    public float jumpStr = -11.0f;
    [SerializeField] float velocity;
    float gravityMultiplier = 3.0f;

    CharacterController controller;

    public Animator playerAnim;
    public Animator cameraAnim;

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

        Mathf.Clamp(velocity, -1.0f, 12.0f);//CLAMPING VELOCITY SO PLAYER DOESNT SKY ROCKET
        if(velocity > 12.0f)
        {
            velocity = 12.0f;
        }

        //Debug.Log(movement.magnitude);

        if (!IsGrounded() && velocity < -12.0f)//negitive for when falling
        {
            isFalling = true;
        }

        if(IsGrounded() && velocity < 0.5f)
        {
            if (isFalling == true)
            {
                cameraAnim.SetTrigger("shake");
                GetComponent<AudioSource>().PlayOneShot(boneCrack);
                GetComponent<AudioSource>().PlayOneShot(hittingTheGround);

            }
            isFalling = false;

            playerAnim.SetFloat("Moving", movement.magnitude);
            velocity = -1;

            
            
        }
        else//falling
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

    public void WalkingBackwards(InputAction.CallbackContext ctx)
    {
        if(!IsGrounded())
        {
            return;
        }
        if(ctx.performed && isFalling != true)
        {
            speed = 4;
            playerAnim.SetBool("Backward", true);
        }
        else
        {
            speed = 8;
            playerAnim.SetBool("Backward", false);
        }
     
    }

    bool jumpWait = false;
    bool push = false;
    public void Jump(InputAction.CallbackContext ctx)
    {

        if (!IsGrounded())//Not grounded? exits function
        {
            return;
        }
        
        if (ctx.performed && jumpWait != true && isFalling != true)
        {
            push = true;
            if(push == true)
            {
                //anim Jump
                StartCoroutine(AnimEngineJumpWait(0.3f));
                jumpWait = true;
            }
        }
    }

    IEnumerator AnimEngineJumpWait(float seconds)
    {
        speed = 8;
        playerAnim.SetBool("Backward", false);//checks

        Debug.Log("Setting Jump Trigger");
        playerAnim.SetBool("Jump",true);

        yield return new WaitForSeconds(seconds);
        
        Debug.Log("Pushing Player Up");
        velocity *= jumpStr;
        
        Debug.Log("Velocity from jump:" +  velocity);


        playerAnim.SetBool("Jump", false);
        yield return new WaitForSeconds(1f);

        push = false;
        jumpWait = false;
    }
    
}
