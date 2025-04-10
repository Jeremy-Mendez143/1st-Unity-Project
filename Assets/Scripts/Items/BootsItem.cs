using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsItem : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("Boots boost applied");

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        playerStats.currentMoveSpeed *= 1 + itemData.Multiplier / 100f;
    }

}