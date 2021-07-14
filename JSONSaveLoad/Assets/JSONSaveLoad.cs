using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONSaveLoad : MonoBehaviour
{
    public InventoryItems inventoryItems;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            SaveInventoryItems();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            LoadInventoryItems();
    }

    public void SaveInventoryItems()
    {
        var data = JsonUtility.ToJson(inventoryItems);
        PlayerPrefs.SetString("Data", data);

        Debug.Log("Saved");
    }

    public void LoadInventoryItems()
    {
        inventoryItems = JsonUtility.FromJson<InventoryItems>(PlayerPrefs.GetString("Data"));

        Debug.Log("Loaded");
    }
}

[System.Serializable]
public class InventoryItems
{
    public List<Item> items = new List<Item>();
}

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemDamage;
}