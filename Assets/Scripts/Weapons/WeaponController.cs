using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <Summary>
// Base Script for all weapon controllers
// </Summary>

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;

    float currentCooldown;

    protected PlayerMovement pm;
    PlayerStats playerStats;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        pm = FindObjectOfType<PlayerMovement>();

        currentCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        currentCooldown -= Time.deltaTime;

        // Once the cooldown becomes 0, attack
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

    virtual protected void Attack()
    {
        currentCooldown = weaponData.CooldownDuration - 1*((100 - playerStats.attackSpeed)/100);
    }
}
