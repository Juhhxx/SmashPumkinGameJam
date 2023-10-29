using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator       _playerAnimator;
    [SerializeField] private KeyCode        _smashButton;
    [SerializeField] private Animator       _pumpkin;
    [SerializeField] private AnimationClip      _smashAnimation;
    [SerializeField] private Player         _playerData;
    [SerializeField] private GameController _gameController;
    [SerializeField] private PumpkinSpawner _pumpkinS;
    private PumpkinController _pumpkinC;

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

        if (_pumpkinS.CurrentPumpkin != null)
            _pumpkinC = _pumpkinS.CurrentPumpkin.GetComponent<PumpkinController>();


        //ver se o jogo começou
        if (_gameController.GameStarted && !_gameController.GameEnd)
        {

            
            //Se o input for negativo e a anima��o n�o estiver a dar
            if (Input.GetKeyDown(_smashButton)  && !_isPlayingAnimation)
            {
               
                _isPlayingAnimation = true;
                //d� play a anima��o
                _playerAnimator.Play(_smashAnimation.name);

            }
        }
        //V� se o jogo acabou
      

        
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
        if (collision.tag == "Pumpkin" && _pumpkinC.GhasFallen)
        {
           
            _playerData.Score += 1;
            
        }
        else if (collision.tag == "BadPumpkin" && _pumpkinC.GhasFallen)
        {
            _playerData.Score -= 1;
        }
        else if (collision.tag == "GoldenPumpkin" && _pumpkinC.GhasFallen)
        {
            _playerData.Score += 3;
        }
        else if (collision.tag == "fail")
        {
            Debug.Log("Failllll");
        }
        UpdateScore.Invoke();



    }
}
