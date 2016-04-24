using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class ItemContainer {
    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<Item> items = new List<Item>();

    public static ItemContainer Load(string path) {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer _ser = new XmlSerializer(typeof(ItemContainer));

        StringReader _read = new StringReader(_xml.text);

        ItemContainer items = _ser.Deserialize(_read) as ItemContainer;

        _read.Close();

        return items;
    }
}
