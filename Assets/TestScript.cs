using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    AttributeManager attributeManager;

    private void Start() {
        attributeManager = AttributeManager.instance;
    }

    public void IncreaseSpeed(float value)
    {
        attributeManager.UpdateAttribute("player_attackspeed_multiplier", value);
    }
}
