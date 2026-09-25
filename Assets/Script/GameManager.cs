using System;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _winningScore;
    
    public GameState CurrentState;

    private int _score;
    public int Score
    {
        get => _score;
        set => _score = value;
    }
    
    private float _timeActive;

    private bool _startGameCloseCountdown;
    private float _timeUntilGameClose = 5f;
    
    public enum GameState
    {
        Gaming,
        Win,
        Lose
    }

    private void LateUpdate()
    {
        if (_score >= _winningScore) CurrentState = GameState.Win;
        
        if (_startGameCloseCountdown) _timeUntilGameClose -= Time.deltaTime;
        else _timeActive += Time.deltaTime;
        
        switch (CurrentState)
        {
            case GameState.Gaming:
                UpdateUI();
                break;
            case GameState.Win:
                _timerText.text = "<color=#ffff00>YOU WIN! </color>" + TimeSpan.FromSeconds(_timeActive).ToString(@"mm\:ss", CultureInfo.InvariantCulture);
                _startGameCloseCountdown = true;
                break;
            case GameState.Lose:
                _timerText.text = "<color=#ff0000>YOU LOSE! </color>";
                _startGameCloseCountdown = true;
                break;
        }

        if (_timeUntilGameClose <= 0)
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    private void UpdateUI()
    {
        _timerText.text = "<color=#ffff00>TIME </color>" + TimeSpan.FromSeconds(_timeActive).ToString(@"mm\:ss", CultureInfo.InvariantCulture);
        _scoreText.text = "<color=#ffff00>SCORE </color>" + _score;
    }
}
