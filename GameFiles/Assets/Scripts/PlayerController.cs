using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed;

    private PlayerMotor motor;

	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	void Update () {
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Vertical");

        Vector2 movVertical = transform.up * _y;
        Vector2 movHorizontal = transform.right * _x;

        Vector2 velocity = (movVertical + movHorizontal).normalized * speed;
        Debug.Log(velocity);
        motor.Move(velocity);
	}
}
