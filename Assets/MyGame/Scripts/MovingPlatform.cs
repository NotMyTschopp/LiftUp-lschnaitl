using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private Camera cam;
    private Vector3 viewPort;
    private float speed;
    
	// Use this for initialization
	private void Start ()
    {
        cam = Camera.main;
        viewPort = cam.ViewportToWorldPoint(new Vector3(cam.rect.width, cam.rect.height, 0));

        speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	private void FixedUpdate ()
    {
        transform.Translate(new Vector3(0, speed, 0));

        if (transform.position.y > viewPort.y)
        {
            Destroy(gameObject);
        }
	}
}
