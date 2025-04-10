using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/Item")]
public class ItemScriptableObject : ScriptableObject
{
    //Add any stats that an item might need
    //NOTE: We might have to separate items in the future and create a DamageItemScriptableObject, HealingItemScriptableObject and etc. 
    [SerializeField]
    string itemName;
    public string ItemName { get { return itemName; } set { itemName = value; } }

    [SerializeField]
    float multiplier;
    public float Multiplier {  get { return multiplier; } set {  multiplier = value; } }

    [SerializeField]
    int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

}
