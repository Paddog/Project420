using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed;

    private PlayerMotor motor;
    private Animator mainAnim;
    private ItemLoader itemDatabase;//TEMP
    public Item itemInHand;

    private GameObject gameObjectInfront;
    private Vector2 velocity;
    private Vector2 lastFrameVelocity;
    void Start () {
        motor = GetComponent<PlayerMotor>();
        mainAnim = GetComponent<Animator>();
        itemDatabase = GameObject.Find("_GameManager").GetComponent<ItemLoader>();
        itemInHand = itemDatabase.ItemDatabase["Cabinet"];
    }

    void Update() {
        GetMovement();
        Debug.Log(itemInHand);
        //TODO: Disable the collider for the time the GameObject is in the hand
        Placement();

    }
    //TODO: REDO this !
    void Placement() {
        if(itemInHand != null) {
            if(itemInHand.Type == ItemTypes.Furniture) {
                //Show the item infront of the char
                if(gameObjectInfront == null) {
                    gameObjectInfront = Instantiate(itemDatabase.ItemPrototypes[itemInHand]);
                } else {
                    //Move the Object
                    //TODO: better placement option
                    Point pointPos = new Point((int)this.transform.position.x, (int)this.transform.position.y);
                    gameObjectInfront.transform.position = new Vector3(pointPos.x, pointPos.y, 0);
                }
                if(Input.GetKeyUp(KeyCode.E)) {
                    itemInHand = null;
                    gameObjectInfront = null;
                }
            }
        }
    }

    void GetMovement() {
        lastFrameVelocity = velocity;
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
        velocity = (movVertical + movHorizontal).normalized * speed;
        motor.Move(velocity);
    }

}
