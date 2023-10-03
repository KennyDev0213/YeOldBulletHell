using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator _door;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _door.GetComponent<Animator>();
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playerScore > 50)
        {
            _door.SetBool("Dooropen", true);
        }
        else 
        {
            _door.SetBool("Dooropen", false);
        }
    }
}
