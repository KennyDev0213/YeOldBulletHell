using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerGravity : MonoBehaviour {
    
    CharacterController characterController;

    float fallSpeed = 2.8f;

    private void Start() {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        if(!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }
}