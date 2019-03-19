using UnityEngine;
using TMPro;

public class DeathSceenUiUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        scoreText.text = SaveFile.Instance.currentScore.ToString();
        timeText.text = SaveFile.Instance.currentTime.ToString();
    }
}
