using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator _player1;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _player1.Play("Smash");
        
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
    }
}
