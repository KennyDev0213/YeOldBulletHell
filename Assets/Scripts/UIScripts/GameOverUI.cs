using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText, statText;
    string scoreHeader = "Score:";
    
    public void UpdateScore(string score)
    {
        scoreText.text = $"{scoreHeader} {score}";
    }

    public void UpdateStatistics()
    {
        Dictionary<string, float> stats =  PlayerStatistics.instance.GetStatistics();

        string statString = "";

        //BEGIN TIME CONVERSION

        float secs = stats["Time Alive"];;

        float mins = ((int) secs) *  1 / 60;
        float hours = ((int)mins) * 1 / 60;

        secs -= mins * 60;
        mins -= hours * 60;

        statString += $"Time Alive: {(int) hours}:{(int) mins}:{secs} \n";

        //END TIME CONVERSION

        stats.Remove("Time Alive");

        foreach(KeyValuePair<string, float> stat in stats)
        {
            statString += $"{stat.Key}: {stat.Value} \n";
        }

        statText.text = statString;
    }

    public void ToMain()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }
}
