using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed;

    private PlayerMotor motor;
    private Animator mainAnim;

	void Start () {
        motor = GetComponent<PlayerMotor>();
        mainAnim = GetComponent<Animator>();
	}
	
	void Update () {
        GetMovement();
	}

    void GetMovement() {
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Vertical");
        Debug.Log("Value x: " + _x + "\n" + "Value y: " + _y);
        mainAnim.SetFloat("xAxis", _x);
        mainAnim.SetFloat("yAxis", _y);

        Vector2 movVertical = transform.up * _y;
        Vector2 movHorizontal = transform.right * _x;

        Vector2 velocity = (movVertical + movHorizontal).normalized * speed;
        Debug.Log(velocity);
        motor.Move(velocity);
    }

}
