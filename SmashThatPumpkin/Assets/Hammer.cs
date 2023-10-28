using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator   _player1;
    [SerializeField] private Animator   _player2;
    [SerializeField] private Player     _playerData;
    [SerializeField] private GameController _gameController;

    private int score = 0;
    public Action UpdateScore;

    private bool _isPlayingAnimation;
    // Start is called before the first frame update
    void Awake()
    {
        _playerData.Score = 0;
        _isPlayingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameController.GameStarted)
        {
            float y = Input.GetAxisRaw("Vertical");
            if (y < 0 && !_isPlayingAnimation)
            {
                _isPlayingAnimation = true;
                _player1.Play("Smash");

            }
        }

        if(_gameController.GameEnd)
        {
            print("Game End");
        }

        
    }

    private void EndOfAnimation()
    {
        _isPlayingAnimation = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pumpkin")
        {
            Destroy((collision.gameObject));
            _playerData.Score += 1;
            UpdateScore.Invoke();
        }
        else if (collision.tag == "BadPumpkin")
        {
            Destroy((collision.gameObject));
            _playerData.Score -= 1;
            UpdateScore.Invoke();
        }
        else if (collision.tag == "GoldenPumpkin")
        {
            
            Destroy((collision.gameObject));
            _playerData.Score -= 3;
            UpdateScore.Invoke();
        }
        else if (collision.tag == "fail")
        {
            Debug.Log("Failllll");
        }
        
     
    }
}
