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

    private void OnEnable()
    {
        _hammer.UpdateScore += UpdateScore;
        _gameController.UpdateTimer += UpdateTimer;
    }

    
    private void OnDisable()
    {
        _hammer.UpdateScore -= UpdateScore;
    }
    private void UpdateTimer(int time)
    {
        _timer.text = time.ToString();
    }
    public void UpdateScore()
    {
        _player1Score.text = _player1.Score.ToString();
        //_player2Score.text = _player2.Score.ToString();
    }
}
