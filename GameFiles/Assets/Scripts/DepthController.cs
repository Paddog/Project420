using UnityEngine;
using System.Collections;

public class DepthController : MonoBehaviour {
    public bool isPlacedOnTop = false;
    
    private SpriteRenderer mainRenderer;

    void Start() {
        mainRenderer = this.GetComponent<SpriteRenderer>();
    }

    void LateUpdate() {

        //transform.position.Set(transform.position.x, this.transform.position.y, this.transform.position.y * 0.001f);

        if(isPlacedOnTop == false) {
            mainRenderer.sortingOrder = Mathf.RoundToInt(this.transform.position.y * -1);
         } else {
             mainRenderer.sortingOrder += 1;
         }
        
        //Vector2 mainCameraWorldPos = transform.TransformPoint(Camera.main.WorldToScreenPoint(mainRenderer.bounds.min));
        //mainRenderer.sortingOrder = (int)mainCameraWorldPos.y * -1;
    }
}
