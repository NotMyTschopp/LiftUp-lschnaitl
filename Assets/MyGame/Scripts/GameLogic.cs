using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    [SerializeField] private Behaviour[] scriptsForPlayMode;
    [SerializeField] private GameObject[] gameObjectsForPlayMode;
    [SerializeField] private TextMeshProUGUI expNumberText;
    [SerializeField] private TextMeshProUGUI highscoreNumberText;

    private Timer timer;
    private const string HIGHSCOREKEY = "highscore";

    public int currentExp = 0;
    public int highestExp;
    public int expGainPerFrame = 1;

    private void Start()
    {
        timer = GetComponent<Timer>();
        highestExp = PlayerPrefs.GetInt(HIGHSCOREKEY, 0);
        highscoreNumberText.text = highestExp.ToString();
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

        expNumberText.gameObject.SetActive(true);
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

        timer.Stop();
        Save();

        expNumberText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GainExp ()
    {
        currentExp += expGainPerFrame;
        expNumberText.text = currentExp.ToString();
    }

    private void Save()
    {
        SaveFile.Instance.currentTime = timer.currentStoppedTime;
        SaveFile.Instance.currentScore = currentExp;
        if (currentExp > highestExp)
        {
            PlayerPrefs.SetInt(HIGHSCOREKEY, currentExp);
        }
    }
}
