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

        float secs = stats["Time Alive"];

        Debug.Log(secs);

        int mins = (int) secs * (1/60);
        int hours = mins * (1/60);

        secs -= mins * 60;
        mins -= hours * 60;

        statString += $"Time Alive: {hours}:{mins}:{(int) secs} \n";

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
        SceneManager.LoadScene(0);
    }
}
