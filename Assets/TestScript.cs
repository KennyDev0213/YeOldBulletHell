using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    AttributeManager attributeManager;

    private void Start() {
        attributeManager = AttributeManager.instance;
        Time.timeScale = 0.5f;
    }

    public void IncreaseSpeed(float value)
    {
        attributeManager.UpdateAttribute("player_attackspeed_multiplier", value);
    }
}
