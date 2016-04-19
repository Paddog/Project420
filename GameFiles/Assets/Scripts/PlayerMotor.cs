using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D rb;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        PerformMovement();
	}

    public void Move(Vector2 _velocity) {
        velocity = _velocity;
    }

    void PerformMovement() {
        if(velocity != Vector2.zero) {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
    
}
