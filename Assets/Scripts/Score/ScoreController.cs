using System;
using UnityEngine;
using Zenject;

public class ScoreController : MonoBehaviour
{
    public event Action<int> OnScoreChanged;

    private int _currentScore = 0;

    private CartPicker _cartPicker;
    
    private LevelManager _levelManager;

    [Inject]
    private void Initialize(CartPicker cartPicker, LevelManager levelManager)
    {
        _cartPicker = cartPicker;
        _levelManager = levelManager;
    }

    private void OnEnable()
    {
        if (_cartPicker is not null)
        {
            _cartPicker.OnPickedFigure += HandleScoreChangings;
        }

        if (_levelManager is not null)
        {
            _levelManager.OnTimeEnded += HandleGameEnded;
        }
    }

    private void OnDisable()
    {
        if (_cartPicker is not null)
        {
            _cartPicker.OnPickedFigure -= HandleScoreChangings;
        }

        if (_levelManager is not null)
        {
            _levelManager.OnTimeEnded -= HandleGameEnded;
        }
    }

    private void HandleScoreChangings(int scoreIncrement)
    {
        _currentScore += scoreIncrement;
        
        OnScoreChanged?.Invoke(_currentScore);
    }

    private void HandleGameEnded()
    {
        int highestScore = PlayerPrefs.GetInt(PlayerPrefsConsts.PlayerHighestScoreKey);

        if (_currentScore > highestScore)
        {
            PlayerPrefs.SetInt(PlayerPrefsConsts.PlayerHighestScoreKey, _currentScore);
        }

        PlayerPrefs.SetInt(PlayerPrefsConsts.PlayerScoreKey, _currentScore);

        Debug.Log(_currentScore);
    }
}
