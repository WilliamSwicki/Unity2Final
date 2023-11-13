using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseXAndY =0,
        MouseX= 1,
        MouseY = 2
    }

    public RotationAxis axis = RotationAxis.MouseXAndY;

    public float sensitivityX = 10.0f;
    public float sensitivityY = 10.0f;
    public float maxVerticaleRotation = 45.0f;
    public float minVerticaleRotation = -45.0f;

    float mouseX;
    float mouseY;
    float verticaleRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, mouseX * sensitivityX * Time.deltaTime, 0);
        }
        else if(axis == RotationAxis.MouseY)
        {
            verticaleRotation -= mouseY * sensitivityY * Time.deltaTime;
            verticaleRotation = Mathf.Clamp(verticaleRotation, minVerticaleRotation, maxVerticaleRotation);
            
            float horizontalRotation = transform.localEulerAngles.y;
           
            transform.localEulerAngles = new Vector3(verticaleRotation, horizontalRotation, 0);
        }
        else
        {
            //both axis
            verticaleRotation -= mouseY * sensitivityY;
            verticaleRotation = Mathf.Clamp(verticaleRotation, minVerticaleRotation, maxVerticaleRotation);

            float deltaRotation = mouseX * sensitivityX;
            float horizontalRotation = transform.localEulerAngles.y + deltaRotation;

            transform.localEulerAngles = new Vector3(verticaleRotation, horizontalRotation, 0);
        }
    }

    public void LookValues(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());
        
        mouseX = ctx.ReadValue<Vector2>().x;
mouseY = ctx.ReadValue<Vector2>().y;
    }
}
