using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MapLoader : MonoBehaviour {
    public GameObject tileGO;


    private bool isTile = false;
    private string tileName;
    private int tileX;
    private int tileY;
    private TileType tileType;

    private int Counter = 1;

    //CRITICAL: You have to add every enum of tiletype in here so it can find it!
    private Dictionary<string, TileType> dict = new Dictionary<string, TileType> {
    { "DefaultTile", TileType.DefaultTile },
    { "Floor", TileType.Floor}
    };
    void Start() {
        LoadFromFile("AssetsRoom2.txt");
    }

    public void LoadFromFile(string Filename) {
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + GameManager.EditorFilePathEnding + Filename);
        
        foreach(string line in lines) {
            if(line == "") {
            } else {
                if(isTile) {
                    if(Counter == 1) {
                        Debug.Log(line);
                        tileX = int.Parse(line);
                    } else if(Counter == 2) {
                        tileY = int.Parse(line);
                    } else if(Counter == 3) {
                        tileType = dict[line];
                        isTile = false;
                        GameObject temp = (GameObject)Instantiate(tileGO, new Vector3(tileX, tileY, 0), Quaternion.identity);
                        temp.transform.name = tileName;
                        temp.GetComponent<Tile>().pointPos = new Point(tileX, tileY);
                        temp.GetComponent<Tile>().type = tileType;
                    }

                    Counter += 1;
                    if(Counter == 4) {
                        Counter = 1;
                    }
                }

                if(line.Contains("Tile") && !line.Contains("DefaultTile") || line.Contains("Tile(Clone)") && !line.Contains("DefaultTile")) {
                    isTile = true;
                    tileName = line;
                }
            }
            //Debug.Log("Name: " + tileName + "TilePosX: " + tileX + "TilePosY: " + tileY + "TileType: " + tileType);

        }
    }
}
