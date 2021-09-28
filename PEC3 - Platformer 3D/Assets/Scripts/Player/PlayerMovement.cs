using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //Possible Input modes
    public enum INPUT_MODE
    {
        Mouse,
        Controller
    }

    //Current input mode
    public INPUT_MODE input_mode = INPUT_MODE.Controller;

    //Walking speed
    public float speed = 2f;


    private PlayerInput input;
    private CharacterController character;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        character = GetComponent<CharacterController>();
    }
    void Update()
    {
        //Choose between controller mode
        /*
        switch (input_mode)
        {
            case INPUT_MODE.Mouse:
                LookAtMouse();
                break;
            case INPUT_MODE.Controller:
                LookAtController();
                break;
        }
        */
        LookAtMouse();
        LookAtController();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Updates the player's rotation according to the mouse input
    /// </summary>
    private void LookAtMouse()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, Mathf.Infinity,
                            1 << LayerMask.NameToLayer("Floor")
                            | 1 << LayerMask.NameToLayer("Enemy")))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            transform.rotation = newRotation;
        }
    }

    /// <summary>
    /// Updates the player's rotation according to the right joystick input
    /// </summary>
    private void LookAtController()
    {
        transform.LookAt(transform.position + input.rightJoystickInput);
    }

    /// <summary>
    /// Moves the player's position depending on the inputs
    /// </summary>
    private void Movement()
    {
        character.SimpleMove(input.movementInput * speed * Time.fixedDeltaTime);
    }
}