using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator _player1;
    private int score = 0;

    private bool _isPlayingAnimation;
    // Start is called before the first frame update
    void Awake()
    {
        _isPlayingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");
        print(y);
        if (y < 0 && !_isPlayingAnimation)
        {
            _isPlayingAnimation = true;
            _player1.Play("Smash");

            Debug.Log(score);
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
            Debug.Log("Pumpkin");
            score += 1;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "BadPumpkin")
        {
            Debug.Log("BadPumpkin");
            score -= 1;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "GoldenPumpkin")
        {
            Debug.Log("GoldenPumpkin");
            score += 3;
            Destroy((collision.gameObject));
        }
        else if (collision.tag == "fail")
        {
            Debug.Log("Failllll");
        }
        
        _player1.Play("BackToIdle");
    }
}
