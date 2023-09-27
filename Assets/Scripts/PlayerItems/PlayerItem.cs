using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerItem : MonoBehaviour
{
   public virtual void OnPickup()
    {
        //What the items does on PickUp
    }

    public virtual void ItemActivation()
    {
        //What the item does/ effects it could have on use
    }

    public virtual void ItemDestory()
    {
        //Destorys the Item
    }

}
