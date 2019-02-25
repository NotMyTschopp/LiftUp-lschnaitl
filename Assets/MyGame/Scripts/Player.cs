using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private Camera cam;
    [SerializeField] private float bottomBorderOffset = 3;
    [SerializeField] private float sideBorderOffset = 0;
    [SerializeField] private GameLogic gameLogic;

    private Vector3 viewPort;
    private Rigidbody2D rb;
    
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

        Debug.Log(rb.velocity);

        Movement();
        CheckForBorders();
        
        //Gain Exp if the player is not touching a platform
        if (!isOnPlatform())
        {
            gameLogic.GainExp();
        }
    }
    
    private void Death ()
    {
        SceneManager.LoadScene(1);
    }

    private void Movement ()
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
    }

    private void CheckForBorders ()
    {
        // check if the player touches the screen borders
        if (transform.position.y > viewPort.y + .5 /* adding a buffer so the player doesnt get killed immediately (can be higher than .5) */ ||
            transform.position.y < -viewPort.y - bottomBorderOffset ||
            transform.position.x > viewPort.x + sideBorderOffset ||
            transform.position.x < -viewPort.x - sideBorderOffset)
        {
            Death();
        }
    }

    private bool isOnPlatform ()
    {
        if (rb.velocity.y < -0.5)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
