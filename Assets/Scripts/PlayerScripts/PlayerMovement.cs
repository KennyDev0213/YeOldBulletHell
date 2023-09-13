using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    AttributeManager attributeManager;
    PlayerInput playerInput;

    public float movementSpeed = 5.0f;
    public float playerSpeedMultiplier = 1;
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerInput == null){
            playerInput = PlayerInput.GetInstance();
        }

        attributeManager = AttributeManager.instance;
        UpdateAttributes();
    }

    void Update()
    {
        // Camera rotation
        float horizontalRotation = playerInput.mouseX * mouseSensitivity;
        verticalRotation -= playerInput.mouseY * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Player movement
        float moveForward = playerInput.vertical * movementSpeed * playerSpeedMultiplier * Time.deltaTime;
        float moveSideways = playerInput.horizontal * movementSpeed * playerSpeedMultiplier * Time.deltaTime;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSideways;

        characterController.Move(movement);
    }

    void FixedUpdate()
    {
        UpdateAttributes();
    }

    //updates the attribute if the attribute changes
    void UpdateAttributes()
    {
        playerSpeedMultiplier = attributeManager.GetAttribute("player_movespeed_multiplier");
    }


    // if you want to constrain the player within a specific area, you can do this:
    // transform.position = new Vector3(
    //     Mathf.Clamp(transform.position.x, minX, maxX),
    //     transform.position.y,
    //     Mathf.Clamp(transform.position.z, minZ, maxZ)
    // );
}



