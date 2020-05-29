using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // 'sortingOrder' and 'SpriteRenderer sprite' are used for sorting orders + other sprite-based manipulations.
    Rigidbody2D rb;
    public int sortingOrder = 0;
    SpriteRenderer sprite;

    // Need to define what a 'player' is in the script (this acts as an input in the 'Inspector' when clicking on objects).
    public static GameObject player;
    float walkSpeed = 10.0f;
    float jumpSpeed = 10.0f;

    // This whole section is for 'stopping the player' moving off the camera; purely for me to create 'invisible walls'.
    // This is so the player can't go anywhere I don't want them to go. These can be set in the inspector per scene.
    public float MovementMaxX;
    public float MovementMinX;
    public float MovementMaxY;
    public float MovementMinY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // contains the components of the whatever Rigidbody2D is applied to the object this script is attached to.
        sprite = GetComponent<SpriteRenderer>(); // contains components of the rendered sprite it is attached to.
    }

    // Update is called once per frame
    void Update()
    {
        // if input is any arrow key, any of these if statements will call the same function with a different parameter parsed into it.
        // use the above as a base to understand every if statement here.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovePlayer("up");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MovePlayer("down");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            MovePlayer("left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            MovePlayer("right");
        }

        else
        {
            //do nothing.
        }
    }

    string MovePlayer(string InputDirection)
    {
        switch (InputDirection)
        {
            case ("up"): // Checks if input is 'up arrow'.
                if (transform.position.y < MovementMaxY)
                // If transformation position of 'y' of the object is less than MovementMaxY's values...
                {
                    transform.position = transform.position + Vector3.up * jumpSpeed * Time.deltaTime;
                    //... allow the change of position of the player based on input.
                }
                else
                {
                    break;
                }
                break;


            case ("down"): // Checks if input is 'down'.
                if (transform.position.y > MovementMinY)
                // If transformation position of 'y' of the object is greater than MovementMaxY's values...
                {
                    transform.position = transform.position + Vector3.down * Time.deltaTime;
                    //... allow the change of position of the player based on input.
                }
                else
                {
                    break;
                }
                break;

            case ("left"): // Checks if input is 'left'.
                if (transform.position.x > MovementMinX)
                // If transformation position of 'x' of the object is greater than MovementMaxY's values...
                {
                    transform.position = transform.position + Vector3.left * walkSpeed * Time.deltaTime;
                    //... allow the change of position of the player based on input.
                }
                else
                {
                    break;
                }
                break;

            case ("right"): // Checks if input is 'right'.
                if (transform.position.x < MovementMaxX)
                // If transformation position of 'x' of the object is less than MovementMaxY's values...
                {
                    transform.position = transform.position + Vector3.right * walkSpeed * Time.deltaTime;
                    //... allow the change of position of the player based on input.
                }
                else
                {
                    break;
                }
                break;

            default:
                print("NO INPUT");
                // This shouldn't trigger, but sometimes I'll be surprised.
                // This just catches errors at least.
                break;
        }
        return InputDirection;
    }
}