using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldController : WeaponController
{
    AudioManager audioManager;

    protected override void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedField = Instantiate(weaponData.Prefab);

        //Play sound
        audioManager.PlaySFX(audioManager.forceFieldAttack);

        spawnedField.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedField.transform.parent = transform; //Spawns below this object
    }


}
