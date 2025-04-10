using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleItem : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("Needle boost applied");
        ApplyModifier();

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        //Health over time
        playerStats.currentRecovery *= 1 + itemData.Multiplier / 100f;
    }
}
