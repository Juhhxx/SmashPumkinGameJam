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

    //É um evento que é invocado sempre que o score do jogador é mudado
    //Evento-> Imagina que existe uma conta de Twitter e outras contas dão follow
    //Sempre que esta conta fazer um post as contas que deram follow serão notificadas
    //A mesma coisa acontece com os métodos
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
        //vê se o jogo começou
        if(_gameController.GameStarted)
        {
            //vê o input
            float y = Input.GetAxisRaw("Vertical");
            //Se o input for negativo e a animação não estiver a dar
            if (y < 0 && !_isPlayingAnimation)
            {
               
                _isPlayingAnimation = true;
                //dá play a animação
                _player1.Play("Smash");

            }
        }
        //Vê se o jogo acabou
        if(_gameController.GameEnd)
        {
            //é para meter o fim de ecrã de jogo
            print("Game End");
        }

        
    }

    /// <summary>
    /// Chamado pela animação quando ela acaba
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
