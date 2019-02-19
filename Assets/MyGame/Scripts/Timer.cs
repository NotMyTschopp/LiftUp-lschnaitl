using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private float timerTime = 0;
    private bool startTimer = false;

    [SerializeField] private TextMeshProUGUI timerNumber;

	// Use this for initialization
	void Start ()
    {
        timerTime = 0;
        startTimer = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (startTimer)
        {
            timerTime += Time.deltaTime;
            timerNumber.text = timerTime.ToString("F");
        }

	}
}
