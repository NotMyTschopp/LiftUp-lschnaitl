using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{



    // USE CONCRETE SINGELTON FOR SAVING THE CURRENT SCROE




    [SerializeField] private Behaviour[] scriptsForPlayMode;
    [SerializeField] private GameObject[] gameObjectsForPlayMode;

    public float currentExp = 0;
    public float highestExp;
    public float expGainPerFrame = 0.05f;

    private void Start()
    {
        highestExp = PlayerPrefs.GetFloat("highscore", 0);
    }

    public void StartGame()
    {
        foreach (Behaviour singleScript in scriptsForPlayMode)
        {
            singleScript.enabled = true;
        }

        foreach (GameObject Object in gameObjectsForPlayMode)
        {
            Object.SetActive(true);
        }
    }

    public void EndGame()
    {
        foreach (Behaviour singleScript in scriptsForPlayMode)
        {
            singleScript.enabled = false;
        }

        foreach (GameObject Object in gameObjectsForPlayMode)
        {
            Object.SetActive(false);
        }

        if (currentExp > highestExp)
        {
            PlayerPrefs.SetFloat("highscore", currentExp);
        }
    }

    public void GainExp ()
    {
        currentExp += expGainPerFrame;
    }
}
