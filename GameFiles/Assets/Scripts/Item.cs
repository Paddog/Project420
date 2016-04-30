using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public enum ItemTypes {
    Weed,
    Utilities,
    Furniture,
    //TODO: ETC!
}

public class Item {

    [XmlAttribute("Name")]
    public string Name;
    
    [XmlElement("Type")]
    public ItemTypes Type;
    
    [XmlElement("Stackable")]
    public bool Stackable;

    
    public Texture UISprite;
    public int ID;

    public void CreatePrototype() {
        //CRITICAL: Reactivate if we have UI
        //UISprite = Resources.Load("UI" + Name + GameManager.IngameSpriteFileEnding);
    }

    /*public Item(int _id, string _name, Sprite _ingamesprite, ItemTypes _types, Sprite _uisprite, bool _stackable) {
        ID = _id;
        Name = _name;
        IngameSprite = _ingamesprite;
        Type = _types;
        UISprite = _uisprite;
        Stackable = _stackable;
    }
    */
    
}
