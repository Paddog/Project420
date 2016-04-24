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
        //Get Input for _x and _y
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Vertical");

        //Tell the Animator what Button is pressed
        mainAnim.SetFloat("xAxis", _x);
        mainAnim.SetFloat("yAxis", _y);

        //Get Movement
        Vector2 movVertical = transform.up * _y;
        Vector2 movHorizontal = transform.right * _x;

        //Apply Movement
        Vector2 velocity = (movVertical + movHorizontal).normalized * speed;
        motor.Move(velocity);
    }

}
