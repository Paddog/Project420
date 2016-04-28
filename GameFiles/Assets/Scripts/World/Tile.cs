using UnityEngine;
using System.Collections;
public enum TileType {
    DefaultTile,
    Floor,
}
public class Tile : MonoBehaviour {
    public Sprite Floor;

    public Point pointPos;
    public TileType type = TileType.DefaultTile;

    private SpriteRenderer SR;
    void Start() {
        SR = GetComponent<SpriteRenderer>();
    }

    void Update() {
        switch(type) {
            case TileType.DefaultTile:
                SR.sprite = null;
                break;
            case TileType.Floor:
                SR.sprite = Floor;
                break;
        }
    }
}
