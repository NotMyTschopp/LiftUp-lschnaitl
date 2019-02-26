using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject icePlatform;
    [SerializeField] private float padding;
    [SerializeField] private float offset = 3;
    [SerializeField] private float timeForSpawn = 1;

    private Vector3 viewPort;
    private float timerTime;
    private bool started;

    private void Start()
    {
        viewPort = cam.ViewportToWorldPoint(new Vector3(cam.rect.width, cam.rect.height, 0));
    }

    private void Update()
    {
        if (started)
        {
            if(timerTime > 0)
            {
                timerTime -= Time.deltaTime;
            }
            else if(timerTime <= 0)
            {
                timerTime = timeForSpawn;
                SpawnSinglePlatform();
            }
        }
    }

    private void SpawnSinglePlatform()
    {
        float randX = Random.Range(-viewPort.x + padding, viewPort.x - padding);
        Instantiate(icePlatform, new Vector3(randX, -viewPort.y - offset, 0), Quaternion.identity);
    }

    public void StartSpawning()
    {
        started = true;
    }
}
