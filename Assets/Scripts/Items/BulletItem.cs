using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : PassiveItem, ICollectible
{
    public void Collect()
    {
        inventory.AddPassiveItem(playerStats.weaponIndex, this);

        Debug.Log("Bullet boost applied");

        Destroy(gameObject);
    }

    protected override void ApplyModifier()
    {
        playerStats.currentAttack *= 1 + itemData.Multiplier / 100f;
    }
}
