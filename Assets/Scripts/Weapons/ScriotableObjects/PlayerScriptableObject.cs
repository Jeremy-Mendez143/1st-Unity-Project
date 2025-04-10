using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class PlayerScriptableObject : ScriptableObject
{

    //Starting Weapon
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    //Base Stats
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    float attack;
    public float Attack { get => attack; private set => attack = value; }

    [SerializeField]
    float attackSpeed;
    public float AttackSpeed { get => attackSpeed; private set => attackSpeed = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float critDmg;
    public float CritDmg { get => critDmg; private set => critDmg = value; }

    [SerializeField]
    float critChance;
    public float CritChance { get => critChance; private set => critChance = value; }

    [SerializeField]
    Sprite characterSprite;
    public Sprite CharacterSprite { get => characterSprite; private set => characterSprite = value; }

}
