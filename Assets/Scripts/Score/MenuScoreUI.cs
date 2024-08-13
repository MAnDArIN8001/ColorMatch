using UnityEngine;
using TMPro;

public class MenuScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _highestScoreText;
    [SerializeField] private TMP_Text _lastScoreText;

    private void Start()
    {
        if (_highestScoreText is not null)
        {
            int highestScore = PlayerPrefs.GetInt(PlayerPrefsConsts.PlayerHighestScoreKey);

            _highestScoreText.text = $"Highest: {highestScore}";
        }

        if (_lastScoreText is not null)
        {
            int lastScore = PlayerPrefs.GetInt(PlayerPrefsConsts.PlayerScoreKey);

            _lastScoreText.text = lastScore.ToString();
        }
    }
}
