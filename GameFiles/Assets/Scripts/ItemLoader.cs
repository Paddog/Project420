using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemLoader : MonoBehaviour {
    public const string path = "Items";
    [SerializeField]
    public Dictionary<string, Item> ItemDatabase = new Dictionary<string, Item>();

	void Start () {
        ItemContainer ic = ItemContainer.Load(path);

        foreach(Item item in ic.items) {
            item.Init();
            ItemDatabase.Add(item.Name, item);
        }

        Debug.Log(ItemDatabase["Blockage"].Type);
        Debug.Log(ItemDatabase["Blockage"].IngameSprite);
    
    }
	
}
