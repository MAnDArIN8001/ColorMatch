using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelManager : MonoBehaviour
{
    public event Action OnTimeEnded;

    private bool _isTimeEnded;

    [SerializeField] private int _menuSceneID;

    [SerializeField] private float _timeForLevel;
    private float _currentTime;

    [SerializeField] private Slider _timeSlider;

    private SceneManager _scenManager;

    [Inject]
    private void Initialize(SceneManager scenManager)
    {
        _scenManager = scenManager;
    }

    private void Start()
    {
        _currentTime = _timeForLevel;
    }

    private void FixedUpdate()
    {
        if (_currentTime <= 0 && !_isTimeEnded)
        {
            OnTimeEnded?.Invoke();

            _scenManager.LoadSceneAsync(_menuSceneID);

            _isTimeEnded = true;
        }

        _currentTime -= Time.fixedDeltaTime;

        _timeSlider.value = _currentTime / _timeForLevel;
    }
}
