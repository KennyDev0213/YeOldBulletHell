using UnityEngine;

public class PlayerInteractor : MonoBehaviour {
    
    PlayerInput playerInput;

    public float reach = 1.4f;

    [SerializeField] Camera playerCam;

    private void Start() {
        playerInput = PlayerInput.instance;
    }

    private void Update() {
        if(playerInput.interact)
        {
            Debug.Log("Interact is working");
            Ray camRay = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(camRay, out hit, reach))
            {
                Debug.Log(hit.transform.name);
                Interactable iScript = hit.transform.GetComponent<Interactable>();
                if(iScript != null)
                {
                    iScript.Interact();
                }
            }
        }
    }
}