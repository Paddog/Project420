using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DepthController : MonoBehaviour {

    private SpriteRenderer spriteR;

    void Start() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    void Update() {
        spriteR.sortingOrder = (int)(transform.position.y * -10);
    }
}
