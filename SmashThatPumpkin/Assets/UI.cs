using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI    _player1Score;
    [SerializeField] TextMeshProUGUI    _player2Score;
    [SerializeField] TextMeshProUGUI    _timer;
    [SerializeField] TextMeshProUGUI        _endScreen;
    [SerializeField] Player             _player1;
    [SerializeField] Player             _player2;
    [SerializeField] Hammer             _hammer;
    [SerializeField] GameController     _gameController;

    /// <summary>
    /// dá follow aos eventos
    /// </summary>
    private void OnEnable()
    {
        _hammer.UpdateScore += UpdateScore;
        _gameController.UpdateTimer += UpdateTimer;
        _gameController.Endgame += ShowEndScreen;
    }

    /// <summary>
    /// E dá desfollow, não sei explicar bem, mas é 
    /// necessário fazer isto por segurança
    /// </summary>
    private void OnDisable()
    {
        _hammer.UpdateScore -= UpdateScore;
        _gameController.UpdateTimer -= UpdateTimer;
        _gameController.Endgame -= ShowEndScreen;

    }

    /// <summary>
    /// método para dar update ao timer
    /// </summary>
    /// <param name="time"></param>
    private void UpdateTimer(int time)
    {
        _timer.text = time.ToString();
    }

    private void ShowEndScreen()
    {
        if (_player1.Score > _player2.Score)
            _endScreen.text = "The Winner is " + _player1.name.ToString();
        else if (_player1.Score < _player2.Score)
            _endScreen.text = "The Winner is " + _player2.name.ToString();
        else
            _endScreen.text = "Draw";
    }

    /// <summary>
    /// Método que dá update ao score do jogador
    /// </summary>
    public void UpdateScore()
    {
        _player1Score.text = _player1.Score.ToString();
        //_player2Score.text = _player2.Score.ToString();
    }
}
