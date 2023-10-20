using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    Dictionary<string, float> statistics;

    public static PlayerStatistics instance {get; private set;}

    string[] initStats = {
            "Time Alive", 
            "Enemies Neutralized", 
            "Shots Fired", 
            "Damage Dealt", 
            "Damage Taken", 
            "Items Picked up",
            "Shops Used"
    };

    private void Awake() {
        if(instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start() {
        ResetStatsDictionary();

        UpdateStat("Time Alive", 10000);
    }

    void ResetStatsDictionary()
    {
        //replace the existing dictionary with a new one
        statistics = new Dictionary<string, float>();

        //add the statistics we want to track
        foreach(string stat in initStats)
        {
            statistics.Add(stat, 0);
        }
    }

    public bool SetStat(string statistic, float value) {

        if(!statistics.ContainsKey(statistic)) return false;

        statistics[statistic] = value;
        return true;
    }

    public bool UpdateStat(string statistic, float value) {

        if(!statistics.ContainsKey(statistic)) return false;

        statistics[statistic] += value;
        return true;
    }

    public float GetStat(string stat)
    {
        if (!statistics.ContainsKey(stat)) return -1;
        return statistics[stat];
    }

    public Dictionary<string, float> GetStatistics() {
        return statistics;
    }
}
