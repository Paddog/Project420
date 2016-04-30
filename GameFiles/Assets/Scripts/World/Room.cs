using UnityEngine;
using System.Collections;
[RequireComponent(typeof(RoomCreator))]
public class Room : MonoBehaviour {
    public int sizeX;
    public int sizeY;

    RoomCreator rCreator;

    private Sprite floorSprite;
	void Start () {
        floorSprite = Resources.Load<Sprite>("Floor");

        rCreator = GetComponent<RoomCreator>();
        rCreator.CreateRoom(sizeX, sizeY, "PlayerRoom", floorSprite);
	}
	
	void Update () {
	
	}
}
