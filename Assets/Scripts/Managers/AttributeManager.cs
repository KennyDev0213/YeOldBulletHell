using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{

    private Dictionary<string, float> attributes = new Dictionary<string, float>();
    public static AttributeManager instance {private set; get;}

    private void Awake() {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        InitializeAttributes();
    }

    private void InitializeAttributes()
    {
        StreamReader data = File.OpenText(".\\Assets\\Scripts\\Managers\\attributes.csv");
        bool clearedHeader = false;
        while(true)
        {
            string line = data.ReadLine();

            //this will clear the first line of the csv file which is the header
            if(!clearedHeader)
            {
                clearedHeader = true;
                continue;
            }

            if(line == null) break;

            string[] values = line.Split(",");

            float fvalue;
            try {
                fvalue = float.Parse(values[1]);
            }
            catch(Exception e)
            {
                Debug.LogError($"failure parsing attribute {values[0]} {e}");
                continue;
            }
            

            attributes.Add(values[0], fvalue);
        }

        Debug.Log("Initialized attributes as:");
        foreach(KeyValuePair<string, float> pair in attributes)
        {
            Debug.Log($"{pair.Key} : {pair.Value}");
        }
    }

    public float GetAttribute(string attributeName){
        if (!attributes.ContainsKey(attributeName)){
            Debug.LogWarning($"no attribute found as {attributeName}");
            return 0;
        }

        return attributes[attributeName];
    }

    public void UpdateAttribute(string attributeName, float value)
    {
        if (!attributes.ContainsKey(attributeName))
            Debug.LogWarning($"no attribute found as {attributeName}");

        attributes[attributeName] = value;
    }
}