using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator _player1;
<<<<<<< HEAD

    private bool _isPlayingAnimation;
=======
    private int score = 0;
>>>>>>> 650a036094963366d82315c7c91559de188ae9ce
    // Start is called before the first frame update
    void Awake()
    {
        _isPlayingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        if (y < 0 && _isPlayingAnimation)
        {
            _isPlayingAnimation = true;
            _player1.Play("Smash");
<<<<<<< HEAD
        }
            
    }
    private void Attack()
    {

=======
        
        Debug.Log(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pumpkin")
        {
            Debug.Log("Pumpkin");
            score += 1;
        }
        else if (collision.tag == "BadPumpkin")
        {
            Debug.Log("BadPumpkin");
            score -= 1;
        }
        else if (collision.tag == "GoldenPumpkin")
        {
            Debug.Log("GoldenPumpkin");
            score += 3;
        }
        else if (collision.tag == "fail")
        {
            Debug.Log("Failllll");
        }
        Destroy((collision.gameObject));
        _player1.Play("BackToIdle");
>>>>>>> 650a036094963366d82315c7c91559de188ae9ce
    }
}
