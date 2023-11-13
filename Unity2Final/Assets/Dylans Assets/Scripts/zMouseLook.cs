using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class zMouseLook : MonoBehaviour
{

    public enum RotationAxis
    {
        MouseXAndMouseY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxis axis = RotationAxis.MouseXAndMouseY;

    public float sensitivityX = 1.0f;//sense for player 50x and 10y
    public float sensitivityY = 1.0f;//sense for camera 1x and 50y
    [SerializeField] float maxVerticalRotation = 50.0f;
    [SerializeField] float minVerticalRotation = -45.0f;

    float mouseX;
    float mouseY;
    float verticalRotation = 0.0f;

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
            //just roation x
            transform.Rotate(0, mouseX * sensitivityX * Time.deltaTime, 0);
        }
        else if(axis == RotationAxis.MouseY)
        {
            //just rotation y 
            verticalRotation -= mouseY * sensitivityY * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

            float horizontalRotation = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            //Both rotation X and Y
            verticalRotation -= mouseY * sensitivityY;
            verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

            float deltaRotation = mouseX * sensitivityX;
            float horizontalRotation = transform.localEulerAngles.y + deltaRotation;


            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
    }

    public void LookValues(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());
        mouseX = ctx.ReadValue<Vector2>().x;
        mouseY = ctx.ReadValue<Vector2>().y;
    }
}
