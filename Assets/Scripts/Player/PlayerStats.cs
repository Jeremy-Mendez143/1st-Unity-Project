using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    HealthBar healthBar;

    //Starting Stats
    PlayerScriptableObject playerData;

    //Current Stats
    public float currentHealth;
    public float currentRecovery;
    public float currentMoveSpeed;
    public float currentAttack;
    public float attackSpeed;
    public float maxHealth;

    //Spawned Weapons
    public List<GameObject> spawnedWeapons;

    //Experience and level of the player
    [Header("Experience/Level")]
    public float exp = 0;
    public int level = 1;
    public int expCap;

    //Class for defining a level range and corresponding exp cap increase for that range
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int expCapIncrease;
    }

    public List<LevelRange> levelRanges;

    InventorySystem inventory;
    public int weaponIndex;
    public int passiveItemIndex;


    private void Awake()
    {
        playerData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();
        inventory = GetComponent<InventorySystem>();

        //Get sprite
        Sprite characterSprite = playerData.CharacterSprite;
        this.GetComponent<SpriteRenderer>().sprite = characterSprite;

        //Assign states
        maxHealth = playerData.MaxHealth;
        currentHealth = maxHealth;
        currentRecovery = playerData.Recovery;
        currentMoveSpeed = playerData.MoveSpeed;
        currentAttack = playerData.Attack;
        attackSpeed = playerData.AttackSpeed;

        //Spawn the starting weapon
        SpawnWeapon(playerData.StartingWeapon);
    }

    private void Start()
    {

        //Initialize exp cap as the first exp cap increase
        expCap = levelRanges[0].expCapIncrease;
    }

    public void IncreaseExperience(float amt)
    {
        exp += amt;

        LevelUpCheck();
    }

    public void RestoreHealth(float amt)
    {
        if (currentHealth < playerData.MaxHealth)
        {
            //Add modifier to heal
            amt *= 1 + (currentRecovery / 100);

            currentHealth += amt;

            //If the resulting health is greater than the player's max health
            //So that it doens't exceed their max health
            if (currentHealth > playerData.MaxHealth)
            {
                currentHealth = playerData.MaxHealth;
            }

            healthBar.SetHealth(currentHealth);

        }

    }
    void LevelUpCheck()
    {
        if (exp >= expCap)
        {
            //Level up and reset the current exp
            level++;
            exp -= expCap;

            int expCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {

                if (level >= range.startLevel && level <= range.endLevel)
                {
                    expCapIncrease = range.expCapIncrease;
                    break;
                }
            }

            expCap += expCapIncrease;
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        if (weaponIndex >= inventory.weaponSlots.Count - 1) //List starts counting from 0
        {
            Debug.LogError("Inventory is full.");
            return;
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());

        weaponIndex++;
    }

    public void SpawnPassiveItem(GameObject weapon)
    {
        if (weaponIndex >= inventory.weaponSlots.Count - 1) //List starts counting from 0
        {
            Debug.LogError("Inventory is full.");
            return;
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());

        weaponIndex++;
    }
}
