using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Vari�veel para ser mais f�cil de configurar
    [SerializeField] private float          _timeToGameStart;
    //Vari�vel para ser mais f�cil de configurar
    [SerializeField] private float          _timeOfGame;
    
    [SerializeField] private Collider2D       _hammer;


    private float       _timer;
    private bool        _gameStarted;
    private bool        _gameEnd;

    //Propriedade para passar o valor da variavel sem ter que mete-la  a public
    public bool GameStarted => _gameStarted;

    //Propriedade para passar o valor da variavel sem ter que mete-la  a public
    public bool GameEnd =>  _gameEnd;

    //� um evento que � invocado sempre que o score do jogador � mudado
    //Evento-> Imagina que existe uma conta de Twitter e outras contas d�o follow
    //Sempre que esta conta fazer um post as contas que deram follow ser�o notificadas
    //A mesma coisa acontece com os m�todos
    public Action<int> UpdateTimer;


    /// <summary>
    /// D� os valores �s vari�veis
    /// </summary>
    void Awake()
    {

        _timer = _timeToGameStart;
        _gameStarted = false;
        _gameEnd = false;

    }

    private void Start()
    {
        //Inicio da coroutina Timer
        StartCoroutine(Timer());
    }


    
    /// <summary>
    /// M�todo chamado no fim da coroutina Timer 
    /// </summary>
    private void GameStart()
    {
        StopCoroutine(Timer());
        _gameStarted = true;
        // define o novo tempo para o tempo de jogo
        _timer = _timeOfGame;
        //come�a a coroutina de contagem de tempo do jogo
        StartCoroutine(InGameTimer());
    }

    //M�todo chamado no fim da coroutina InGameTimer
    private void SetGameEnd()
    {
        _gameEnd = true;
    }


 


    
    /// <summary>
    /// � tipo um cronometro que conta o tempo at� o come�o do jogo
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Cron�metro que conta o tempo passado no jogo
    /// </summary>
    /// <returns></returns>
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
