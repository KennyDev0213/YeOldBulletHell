using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    PlayerInput playerInput;
    GameManager gameManager;

    [SerializeField] TMP_Text healthText, scoreText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseMenu;

    private Health playerHealth;

    private bool isPaused = false;

    void Start()
    {
        playerInput = PlayerInput.instance;
        playerHealth = player.GetComponent<Health>();

        gameManager = GameManager.instance;
    }


    void Update()
    {
        if(healthText != null)
            UpdateHealth();
        
        if(scoreText != null)
            UpdateScore();

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
        playerInput.fixPlayerInput = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerInput.ClearInputs();
    }

    public void Unpause()
    {
        playerInput.fixPlayerInput = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UpdateHealth()
    {
        healthText.text = $"Health:{playerHealth.health} / {playerHealth.maxHealth}";
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {gameManager.playerScore}";
    }
}
