using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Adjust this to control movement speed
    [SerializeField] private float jumpForce = 10f; //Adjust this to control the jump speed
    private bool isGrounded; // Check if the player is grounded

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply the movement to the player's position
        transform.Translate(movement);


        isGrounded = Physics.Raycast(transform.position, Vector3.down, 5f);

        Debug.Log(isGrounded);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force for jumping
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumpped!");
        }

        // if you want to constrain the player within a specific area, you can do this:
        // transform.position = new Vector3(
        //     Mathf.Clamp(transform.position.x, minX, maxX),
        //     transform.position.y,
        //     Mathf.Clamp(transform.position.z, minZ, maxZ)
        // );
    }
}


