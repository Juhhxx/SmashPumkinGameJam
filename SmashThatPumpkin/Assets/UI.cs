using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI    _player1Score;
    [SerializeField] TextMeshProUGUI    _player2Score;
    [SerializeField] TextMeshProUGUI    _timer;
    [SerializeField] Player             _player1;
    [SerializeField] Player             _player2;
    [SerializeField] Hammer             _hammer;
    [SerializeField] GameController     _gameController;

    /// <summary>
    /// d� follow aos eventos
    /// </summary>
    private void OnEnable()
    {
        _hammer.UpdateScore += UpdateScore;
        _gameController.UpdateTimer += UpdateTimer;
    }

    /// <summary>
    /// E d� desfollow, n�o sei explicar bem, mas � 
    /// necess�rio fazer isto por seguran�a
    /// </summary>
    private void OnDisable()
    {
        _hammer.UpdateScore -= UpdateScore;
    }

    /// <summary>
    /// m�todo para dar update ao timer
    /// </summary>
    /// <param name="time"></param>
    private void UpdateTimer(int time)
    {
        _timer.text = time.ToString();
    }

    /// <summary>
    /// M�todo que d� update ao score do jogador
    /// </summary>
    public void UpdateScore()
    {
        _player1Score.text = _player1.Score.ToString();
        //_player2Score.text = _player2.Score.ToString();
    }
}
