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

    //� um evento que � invocado sempre que o score do jogador � mudado
    //Evento-> Imagina que existe uma conta de Twitter e outras contas d�o follow
    //Sempre que esta conta fazer um post as contas que deram follow ser�o notificadas
    //A mesma coisa acontece com os m�todos
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
        //v� se o jogo come�ou
        if(_gameController.GameStarted)
        {
            //v� o input
            float y = Input.GetAxisRaw("Vertical");
            //Se o input for negativo e a anima��o n�o estiver a dar
            if (y < 0 && !_isPlayingAnimation)
            {
               
                _isPlayingAnimation = true;
                //d� play a anima��o
                _player1.Play("Smash");

            }
        }
        //V� se o jogo acabou
        if(_gameController.GameEnd)
        {
            //� para meter o fim de ecr� de jogo
            print("Game End");
        }

        
    }

    /// <summary>
    /// Chamado pela anima��o quando ela acaba
    /// </summary>
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
