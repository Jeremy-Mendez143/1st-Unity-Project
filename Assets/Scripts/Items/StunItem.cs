using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunItem : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("Stun boost applied");

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        //Idk how to make this one work :(
    }
}
