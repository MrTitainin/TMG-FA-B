using UnityEngine;
using System.Collections.Generic;

public class MovementPlayer : MonoBehaviour
{
    // Movement modifier applied to directional movement.
    public float playerSpeed = 2.0f;

    // What the current speed of our player is
    private float currentSpeed = 0.0f;
    private static bool playerExists;

    /*
    * Allows us to have multiple inputs and supports keyboard,
    * joystick, etc.
    */
    public List<KeyCode> upButton;
    public List<KeyCode> downButton;
    public List<KeyCode> leftButton;
    public List<KeyCode> rightButton;
    public List<KeyCode> dialogButton;

    
    public bool canMove;

    public string startPoint;

    // The last movement that we've made
    private Vector3 lastMovement = new Vector3();

    private Rigidbody2D m_Rigidbody;
    //START
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>() as Rigidbody2D;
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }else
        {
            Destroy(gameObject);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        // Rotate player to face mouse
        //Rotation();
        // Move the player's body
        if (!canMove)
        {

            m_Rigidbody.velocity = Vector2.zero;
            return;
        }
        Movement();
    }
    // Will rotate the ship to face the mouse.
    /*void Rotation()
    {
        // We need to tell where the mouse is relative to the
        // player
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        /*
           * Get the differences from each axis (stands for
           * deltaX and deltaY)
       
        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        // Get the angle between the two objects
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        /*
           * The transform's rotation property uses a Quaternion,
           * so we need to convert the angle in a Vector
           * (The Z axis is for rotation for 2D).
       
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        // Assign the ship's rotation
        this.transform.rotation = rot;
    }*/
    // Will move the player based off of keys pressed
    void Movement()
    {
        // The movement that needs to occur this frame
        Vector3 movement = new Vector3();

        // Check for input
        movement += MoveIfPressed(upButton, Vector3.up);
        movement += MoveIfPressed(downButton, Vector3.down);
        movement += MoveIfPressed(leftButton, Vector3.left);
        movement += MoveIfPressed(rightButton, Vector3.right);

        /*
           * If we pressed multiple buttons, make sure we're only
           * moving the same length.
        */
        movement.Normalize();

        // Check if we pressed anything
        if (movement.magnitude > 0)
        {
            // If we did, move in that direction
            currentSpeed = playerSpeed;
            this.transform.Translate(movement * Time.deltaTime *
                                    playerSpeed, Space.World);
            lastMovement = movement;
        }
        else
        {
            // Otherwise, move in the direction we were going
            this.transform.Translate(lastMovement * Time.deltaTime
                                    * currentSpeed, Space.World);
            // Slow down over time
            currentSpeed *= .9f;
        }
    }
    /*
    * Will return the movement if any of the keys are pressed,
    * otherwise it will return (0,0,0)
    */
    Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement)
    {
        // Check each key in our list
        foreach (KeyCode element in keyList)
        {
            if (Input.GetKey(element))
            {
                /*
                  * It was pressed so we leave the function
                  * with the movement applied.
                */
                return Movement;
            }
        }

        // None of the keys were pressed, so don't need to move
        return Vector3.zero;
    }
}

