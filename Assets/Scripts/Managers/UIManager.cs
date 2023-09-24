using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text maxhealthText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseMenu;

    private Health playerHealth;

    private bool isPaused = false;

    void Start()
    {
        playerInput = PlayerInput.instance;
        playerHealth = player.GetComponent<Health>();
    }


    void Update()
    {
        UpdatedHealth();

        //if(playerInput.esc){
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            if(isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UpdatedHealth()
    {
        healthText.text = $"Health: {playerHealth.health}";
        maxhealthText.text = $"/ {playerHealth.maxHealth}";
    }
}
