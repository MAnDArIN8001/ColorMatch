using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isGamePaused;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;

    public void StopGame()
    {
        Time.timeScale = 0;
        _isGamePaused = true;

        ResetMenus();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isGamePaused = false;

        ResetMenus();
    }

    private void ResetMenus()
    {
        _pauseButton.SetActive(!_isGamePaused);
        _pauseMenu.SetActive(_isGamePaused);
    }
}
