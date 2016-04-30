using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemLoader : MonoBehaviour {
    public const string path = "Items";

    //TODO: Switch it to the ItemDatabase
    public Dictionary<string, Item> ItemDatabase = new Dictionary<string, Item>();
    public Dictionary<Item, GameObject> ItemPrototypes = new Dictionary<Item, GameObject>();
	void Start () {
        ItemContainer ic = ItemContainer.Load(path);

        foreach(Item item in ic.items) {
            item.CreatePrototype();
            ItemDatabase.Add(item.Name, item);
            GameObject temp = Resources.Load<GameObject>("IG" + item.Name);
            if(temp == null) {
                Debug.LogError("There was no IGOBJ for: " + item.Name);
            }
            ItemPrototypes.Add(item, temp);
            Debug.Log("Added: " + item.Name);
        }    
    }
	
}
