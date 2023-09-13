using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpItem : PlayerItem
{
    public override void OnPickup()
    {
        Debug.Log("Powerup Pickedup!");
    }

    public override void ItemActivation()
    {
        Debug.Log("Powerup Is now being used");
    }

    public override void ItemDestory()
    {
        base.ItemDestory();
    }
}
