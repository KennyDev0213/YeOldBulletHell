using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;
    [SerializeField] Transform bar;
    float startWidth;

    void Start()
    {
        if(health == null)
        {
            health = GetComponent<Health>();
        }

        startWidth = bar.localScale.x;

        health.onHealthChange.AddListener(ResizeBar);

        health.onHealthChange.AddListener(ChangeColour);

        ChangeColour();

        health.onDeath.AddListener(RemoveBar);
    }

    void ChangeColour()
    {
        float percentage = CalcHealthPercentage();

        MeshRenderer renderer = bar.gameObject.GetComponent<MeshRenderer>();

        if(percentage < 0.2) //20% - 0%
            renderer.material.color = Color.red;
        else if(percentage < 0.5) //50% - 21%
            renderer.material.color = Color.yellow;
        else //100%
            renderer.material.color = Color.green;
    }

    void ResizeBar()
    {
        Debug.Log($"{health.maxHealth} {health.health}");
        float barSize = startWidth * CalcHealthPercentage();
        Debug.Log($"startWidth:{startWidth} HealthPercentage:{CalcHealthPercentage()} BarSize{barSize}");
        bar.localScale = new Vector3 (barSize, bar.localScale.y, bar.localScale.z);
    }

    float CalcHealthPercentage()
    {
        float h1 =  health.health;
        float h2 = health.maxHealth;
        return  h1 / h2;
    }

    void RemoveBar()
    {
        bar.gameObject.SetActive(false);
    }
}
