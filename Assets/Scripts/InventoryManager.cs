using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    //Since unity doesn't allow dictionary to be shown in the editor, 
    //We'll basically map each weapon index to the same weapon levels index

    public List<WeaponController> weaponSlots = new List<WeaponController>(99);
    public List<int> weaponLevels = new List<int>(99);

    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>(99);
    public List<int> passiveItemLevels = new List<int>(99);

    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;

    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
        weaponLevels[slotIndex] = passiveItem.itemData.Level;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if(weaponSlots.Count > slotIndex)
        {
            WeaponController weapon = weaponSlots[slotIndex];

            if(!weapon.weaponData.NextLevelPrefab) //Check if there is a next level for the weapon
            {
                Debug.LogError("NO NEXT LEVEL");
                return;
            }

            GameObject upgradedWeapon = Instantiate(weapon.weaponData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedWeapon.transform.SetParent(transform); //Set the weapon to be the child of the player
            AddWeapon(slotIndex, upgradedWeapon.GetComponent<WeaponController>());
            Destroy(weapon.gameObject);
            weaponLevels[slotIndex] = upgradedWeapon.GetComponent<WeaponController>().weaponData.Level;

        }
    }

    public void LevelUpPassiveItem(int slotIndex)
    {
        if (passiveItemSlots.Count > slotIndex)
        {
            PassiveItem passiveItem = passiveItemSlots[slotIndex];

            if (!passiveItem.itemData.NextLevelPrefab) //Check if there is a next level for the weapon
            {
                Debug.LogError("NO NEXT LEVEL");
                return;
            }

            GameObject upgradedPassiveItem = Instantiate(passiveItem.itemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedPassiveItem.transform.SetParent(transform); //Set the weapon to be the child of the player
            AddPassiveItem(slotIndex, upgradedPassiveItem.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            weaponLevels[slotIndex] = upgradedPassiveItem.GetComponent<PassiveItem>().itemData.Level;

        }
    }

}