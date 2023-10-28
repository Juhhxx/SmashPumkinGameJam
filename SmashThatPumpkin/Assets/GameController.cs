using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Variáveel para ser mais fácil de configurar
    [SerializeField] private float          _timeToGameStart;
    //Variável para ser mais fácil de configurar
    [SerializeField] private float          _timeOfGame;
    
    [SerializeField] private Collider2D       _hammer;


    private float       _timer;
    private bool        _gameStarted;
    private bool        _gameEnd;

    //Propriedade para passar o valor da variavel sem ter que mete-la  a public
    public bool GameStarted => _gameStarted;

    //Propriedade para passar o valor da variavel sem ter que mete-la  a public
    public bool GameEnd =>  _gameEnd;

    //É um evento que é invocado sempre que o score do jogador é mudado
    //Evento-> Imagina que existe uma conta de Twitter e outras contas dão follow
    //Sempre que esta conta fazer um post as contas que deram follow serão notificadas
    //A mesma coisa acontece com os métodos
    public Action<int> UpdateTimer;


    /// <summary>
    /// Dá os valores às variáveis
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
    /// Método chamado no fim da coroutina Timer 
    /// </summary>
    private void GameStart()
    {
        StopCoroutine(Timer());
        _gameStarted = true;
        // define o novo tempo para o tempo de jogo
        _timer = _timeOfGame;
        //começa a coroutina de contagem de tempo do jogo
        StartCoroutine(InGameTimer());
    }

    //Método chamado no fim da coroutina InGameTimer
    private void SetGameEnd()
    {
        _gameEnd = true;
    }


 


    
    /// <summary>
    /// É tipo um cronometro que conta o tempo até o começo do jogo
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
    /// Cronómetro que conta o tempo passado no jogo
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
