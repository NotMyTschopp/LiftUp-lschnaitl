using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timerTime;
    private bool startTimer = false;

    public float currentStoppedTime = 0;

    [SerializeField] private TextMeshProUGUI timerNumber;

	// Use this for initialization
	private void Start ()
    {
        timerTime = 0;
        startTimer = true;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (startTimer)
        {
            timerTime += Time.deltaTime;
            timerNumber.text = timerTime.ToString("F");
        }
	}

    public void Stop ()
    {
        startTimer = false;
        currentStoppedTime = timerTime;
    }
}
