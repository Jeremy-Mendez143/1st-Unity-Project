using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandaid : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("Bandaid boost applied");

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        //Incrase maxHP
        playerStats.maxHealth *= 1 + itemData.Multiplier / 100f;
    }
}
