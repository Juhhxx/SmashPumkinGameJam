using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator   _player1;
    [SerializeField] private Animator   _player2;
    [SerializeField] private Player     _playerData;
    [SerializeField] private GameController _gameContrller;
    
    private int score = 0;
    public Action UpdateScore;

    private bool _isPlayingAnimation;
    // Start is called before the first frame update
    void Awake()
    {
        _isPlayingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        ///if(_gameContrller.GameStarted)
        ///{
            float y = Input.GetAxisRaw("Vertical");
            if (y < 0 && !_isPlayingAnimation)
            {
                _isPlayingAnimation = true;
                _player1.Play("Smash");

                Debug.Log(score);
            }
        ///}
        
    }

    private void EndOfAnimation()
    {
        _isPlayingAnimation = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pumpkin")
        {
            
            _playerData.Score += 1;
            UpdateScore.Invoke();
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "BadPumpkin")
        {
            _playerData.Score -= 1;
            UpdateScore.Invoke();
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "GoldenPumpkin")
        {
            _playerData.Score += 3;
            UpdateScore.Invoke();
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "fail")
        {
            Debug.Log("Failllll");
        }
        
        _player1.Play("BackToIdle");
    }
}
