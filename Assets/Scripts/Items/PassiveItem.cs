using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats playerStats;
    public string itemName;

    public GameObject prefab;

    public ItemScriptableObject itemData;
    public InventorySystem inventory;
    public int itemIndex;

    private void Awake()
    {
        inventory = FindObjectOfType<InventorySystem>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    protected virtual void ApplyModifier()
    {
        //Apply the boost value to the appropriate stat in the child class
    }

    public void SpawnPrefab()
    {
        playerStats.SpawnPassiveItem(this.prefab);

    }

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }

}
