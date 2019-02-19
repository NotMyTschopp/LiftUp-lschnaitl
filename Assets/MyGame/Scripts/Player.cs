using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private Camera cam;
    [SerializeField] private float bottomBorderOffset = 3;
    [SerializeField] private float sideBorderOffset = 0;

    private Vector3 viewPort;
    private Rigidbody2D rb;
    private bool isOnPlatform = false;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = Camera.main;
        viewPort = cam.ViewportToWorldPoint(new Vector3(cam.rect.width, cam.rect.height, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
		//move the player left and right
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        // check if the player touches the screen borders
        if (transform.position.y > viewPort.y + .5 /* adding a buffer so the player doesnt get killed immediately (can be higher than .5) */ || 
            transform.position.y < -viewPort.y - bottomBorderOffset || 
            transform.position.x > viewPort.x + sideBorderOffset || 
            transform.position.x < -viewPort.x - sideBorderOffset)
        {
            Death();
        }

        //Gain Exp if the player is not touching a platform
        if (!isOnPlatform)
        {

        }

    }


    void Death ()
    {
        Debug.Log("Death");
    }
}
