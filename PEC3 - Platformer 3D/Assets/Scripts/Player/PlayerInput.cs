using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 movementInput, rightJoystickInput;
    public bool shotThisFrame, shooting;
    public bool reload;
    public bool jumpedThisFrame;

    void Update()
    {

        Quaternion simplifiedCamera = UpdateCameraQuaternion();

        UpdateRelativeMovementInput(simplifiedCamera);
        UpdateRelativeRightJoystickInput(simplifiedCamera);
        UpdateShootingInput();
        UpdateReloadInput();
        UpdateJumpInput();
    }

    /// <summary>
    /// Updates the Quaternion that represents the forward vector of the main camera
    /// </summary>
    /// <returns>Updated Quaternion</returns>
    private Quaternion UpdateCameraQuaternion()
    {
        Quaternion simplifiedCamera = new Quaternion();
        simplifiedCamera.eulerAngles = new Vector3(
                                    0f,
                                    Camera.main.transform.rotation.eulerAngles.y,
                                    0f);
        return simplifiedCamera;
    }

    /// <summary>
    /// Updates the movement input relative to the given Quaternion's Z axis
    /// </summary>
    /// <param name="relativeToQuaternion">Quaternion used for relativity of input
    /// </param>
    private void UpdateRelativeMovementInput(Quaternion relativeToQuaternion)
    {
        //Gets horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Normalizes the input. This way, a character can't walk faster in diagonal
        //than in vertical or horizontal
        Vector2 normalizedInput = new Vector2(horizontalInput, verticalInput).normalized;

        //Relativizes the input and gives it the float value of the input axis
        movementInput = normalizedInput.x * Mathf.Abs(horizontalInput)
                        * (relativeToQuaternion * Vector3.right) +
                        normalizedInput.y * Mathf.Abs(verticalInput)
                        * (relativeToQuaternion * Vector3.forward);
    }

    /// <summary>
    /// Updates the right joystick input relative to the given Quaternion's Z axis
    /// </summary>
    /// <param name="relativeToQuaternion">Quaternion used for relativity of input
    /// </param>
    private void UpdateRelativeRightJoystickInput(Quaternion relativeToQuaternion)
    {
        //Gets horizontal and vertical input for the right joystick
        float horizontalJoystick = Input.GetAxis("Joystick X");
        float verticalJoystick = -Input.GetAxis("Joystick Y");

        //Normalizes the input
        Vector2 normalizedRightJoystickInput =
                        new Vector2(horizontalJoystick, verticalJoystick).normalized;

        //Relativizes the input and gives it the float value of the input axis
        rightJoystickInput =
                normalizedRightJoystickInput.x * Mathf.Abs(horizontalJoystick) *
                (relativeToQuaternion * Vector3.right) +
                normalizedRightJoystickInput.y * Mathf.Abs(verticalJoystick) *
                (relativeToQuaternion * Vector3.forward);
    }

    /// <summary>
    /// Updates the shooting input variables
    /// </summary>
    private void UpdateShootingInput()
    {
        //Shoot input
        shotThisFrame = Input.GetButtonDown("Fire1");
        shooting = Input.GetButton("Fire1");
    }

    /// <summary>
    /// Updates the reloading input variable
    /// </summary>
    private void UpdateReloadInput()
    {
        reload = Input.GetButtonDown("Reload");
    }

    /// <summary>
    /// Updates the jumping input variable
    /// </summary>
    private void UpdateJumpInput()
    {
        jumpedThisFrame = Input.GetButtonDown("Jump");
    }
}
