using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 2;
    [SerializeField] private Camera mainCam;
    private Vector3 viewPort;

    Rigidbody2D rb;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCam = Camera.main;
        viewPort = mainCam.ViewportToWorldPoint(new Vector3(mainCam.rect.width, mainCam.rect.height, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
		//move the player left and right
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
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
        if (transform.position.y > viewPort.y || 
            transform.position.y < -viewPort.y || 
            transform.position.x > viewPort.x || 
            transform.position.x < -viewPort.x)
        {
            Death();
        }

    }


    void Death ()
    {
        Debug.Log("Death");
    }
}
