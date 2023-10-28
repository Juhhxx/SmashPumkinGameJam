using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private Animator _player1;

    private bool _isPlayingAnimation;
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
        }
            
    }
    private void Attack()
    {

    }
}
