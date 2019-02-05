using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    [SerializeField] private Behaviour[] scriptsForPlayMode;

	public void StartGame()
    {
        foreach (Behaviour singleScript in scriptsForPlayMode)
        {
            singleScript.enabled = true;
        }
    }

    public void EndGame()
    {
        foreach (Behaviour singleScript in scriptsForPlayMode)
        {
            singleScript.enabled = false;
        }
    }
}
