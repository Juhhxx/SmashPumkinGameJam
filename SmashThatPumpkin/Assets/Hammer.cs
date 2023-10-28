using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator _player1;
    [SerializeField] private KeyCode _smash;
    [SerializeField] private KeyCode _pass;

    private bool _isPlayingAnimation;

    private int score = 0;

    void Awake()
    {
        _isPlayingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(_isPlayingAnimation);
        if (Input.GetKeyDown(_smash) && !_isPlayingAnimation)
        {
             
            _isPlayingAnimation = true;
            _player1.Play("Smash");

        }
            
    }
    private void EndOfAnimation()
    {

        _isPlayingAnimation = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "fail")
        //{

        //    Debug.Log("Failllll");
        //    return;
        //}
        if (collision.tag == "Pumpkin")
        {
            score += 1;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "BadPumpkin")
        {
            score -= 1;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "GoldenPumpkin")
        {
            score += 3;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "fail")
        {
        }
        
        _player1.Play("BackToIdle");

    }
}
