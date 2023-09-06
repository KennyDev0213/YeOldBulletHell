using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Camera rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Player movement
        float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float moveSideways = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSideways;

        characterController.Move(movement);
    }

    // if you want to constrain the player within a specific area, you can do this:
    // transform.position = new Vector3(
    //     Mathf.Clamp(transform.position.x, minX, maxX),
    //     transform.position.y,
    //     Mathf.Clamp(transform.position.z, minZ, maxZ)
    // );
}



