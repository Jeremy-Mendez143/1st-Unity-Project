using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemListText : MonoBehaviour
{
    private InventorySystem inventory;
    public string itemListString;
    public TextMeshProUGUI itemListText;

    private void Start()
    {
        itemListString = "";
        inventory = FindObjectOfType<InventorySystem>();
        UpdateItemListText();
    }

    void UpdateItemListText()
    {
        //TODO:: SHOW ITEMS
    }

}