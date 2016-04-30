using UnityEngine;
using System.Collections;

//TODO: Still not sure how i should do it.
//Creates a seperate room its "split" from the outside world.
public class RoomCreator : MonoBehaviour {

    public void CreateRoom(int width = 5, int height = 5, string name = "Default", Sprite floorSprite = null) {
        GameObject room;
        if(!GameObject.Find(name)) {
            room = new GameObject(name);
        } else {
            room = GameObject.Find(name);
        }

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {

                //Create GameObject and add the SpriteRenderer component and the Tile script.
                GameObject TileGO = new GameObject("Tile_" + x + "_" + y);

                SpriteRenderer sR = TileGO.AddComponent<SpriteRenderer>();
                Tile tileScript = TileGO.AddComponent<Tile>();

                //Set the sprite, sortingOrder
                sR.sortingOrder = -10000;
                //CRITICAL: REDO THIS!
                tileScript.type = TileType.Floor;
                tileScript.Floor = floorSprite;

                //TODO: Maybe do some function in Tile
                //so that the Tile Script creates, sets the pointPos and resets the Transform to that pointPos.
                TileGO.transform.position = new Vector3(x, y, 0);
                tileScript.pointPos = new Point(x, y);

                //Parent it to the RoomGameObject
                TileGO.transform.parent = room.transform;
            }
        }
        //TODO: Create walls on the sides
    }



    private void CreateFloor(int width, int height) {

    }
}
