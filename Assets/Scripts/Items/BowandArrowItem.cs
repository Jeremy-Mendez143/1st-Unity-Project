using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowandArrowItem : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("BowArrow boost applied");

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        playerStats.attackSpeed *= 1 + itemData.Multiplier / 100f;
    }

}