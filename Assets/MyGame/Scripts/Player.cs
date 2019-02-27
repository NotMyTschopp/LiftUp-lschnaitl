using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Camera cam;
    [SerializeField] private float bottomBorderOffset = 3;
    [SerializeField] private float sideBorderOffset = 0;
    [SerializeField] private GameLogic gameLogic;

    private Vector3 viewPort;
    private Rigidbody2D rb;
    private float topScreenBuffer = 0.5f;
    private float fallingCapVelocity = -0.5f;

    // Use this for initialization
    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        
        cam = Camera.main;
        viewPort = cam.ViewportToWorldPoint(new Vector3(cam.rect.width, cam.rect.height, 0));
    }
	
	// Update is called once per frame
	private void Update ()
    {
        Movement();
        CheckForBorders();
        
        //Gain Exp if the player is not touching a platform
        if (!IsOnPlatform())
        {
            gameLogic.GainExp();
        }
    }
    
    public void Death ()
    {
        gameLogic.EndGame();
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
        if (transform.position.y > viewPort.y + topScreenBuffer || // adding a buffer so the player doesnt get killed immediately (can be higher than .5)
            transform.position.y < -viewPort.y - bottomBorderOffset ||
            transform.position.x > viewPort.x + sideBorderOffset ||
            transform.position.x < -viewPort.x - sideBorderOffset)
        {
            Death();
        }
    }

    private bool IsOnPlatform ()
    {
        if (rb.velocity.y < fallingCapVelocity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
