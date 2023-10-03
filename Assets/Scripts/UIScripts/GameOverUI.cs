using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    string scoreHeader = "Score:";
    
    public void UpdateScore(string score)
    {
        scoreText.text = $"{scoreHeader} {score}";
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }
}
