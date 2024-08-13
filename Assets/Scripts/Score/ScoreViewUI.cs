using UnityEngine;
using Zenject;
using TMPro;

public class ScoreViewUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private ScoreController _scoreController;

    [Inject]
    private void Initialize(ScoreController scoreController)
    {
        _scoreController = scoreController;
    }

    private void OnEnable()
    {
        if (_scoreController is not null)
        {
            _scoreController.OnScoreChanged += HandleScoreChangings;
        }
    }

    private void OnDisable()
    {
        if (_scoreController is not null)
        {
            _scoreController.OnScoreChanged -= HandleScoreChangings;
        }
    }

    private void HandleScoreChangings(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
