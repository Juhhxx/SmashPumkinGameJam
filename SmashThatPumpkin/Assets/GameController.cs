using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float          _timeToGameStart;
    [SerializeField] private float          _timeOfGame;
    
    [SerializeField] private Collider2D       _hammer;


    private float       _timer;
    private bool        _gameStarted;
    private bool        _gameEnd;


    public bool GameStarted => _gameStarted;

    public bool GameEnd =>  _gameEnd;

    public Action<int> UpdateTimer;


    // Start is called before the first frame update
    void Awake()
    {

        _timer = _timeToGameStart;
        _gameStarted = false;
        _gameEnd = false;

    }

    private void Start()
    {
        StartCoroutine(Timer());
    }


    

    private void GameStart()
    {
        StopCoroutine(Timer());
        _gameStarted = true;
        _timer = _timeOfGame;
        StartCoroutine(InGameTimer());
    }

    private void SetGameEnd()
    {
        _gameEnd = true;
    }


 


    

    IEnumerator Timer()
    {
        int intTime;
        while(_timer>1)
        {
            
            _timer -= Time.deltaTime;
            intTime = (int)_timer;
            UpdateTimer.Invoke(intTime);
            yield return null;
        }
       
      
            GameStart();
        
    }

    IEnumerator InGameTimer()
    {
        int intTime;
        while (_timer > 1)
        {

            _timer -= Time.deltaTime;
            intTime = (int)_timer;
            UpdateTimer.Invoke(intTime);
            yield return null;
        }


        SetGameEnd();
    }
}
