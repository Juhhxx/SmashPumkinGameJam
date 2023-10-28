using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _timeToWait;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Collider2D       _hammer;


    private Controller _controller;
    private float      _timer;

    
    // Start is called before the first frame update
    void Awake()
    {
        _controller = new Controller();
        //_controller.Controller1.MovePlayer2.performed += ctx => Test();
        _timer = _timeToWait;
    }

    private void Start()
    {
        StartCoroutine(Timer(_timeToWait));
    }

    

    private void GameStart()
    {
        StopCoroutine(Timer(_timeToWait));
        print("Initial Game");
    }

    private void Update()
    {
      

        
        
    }

    

    IEnumerator Timer(float TimeToWait)
    {
        int intTime;
        while(_timer>1)
        {
            
            _timer -= Time.deltaTime;
            intTime = (int)_timer;
            _textMesh.text = intTime.ToString();
            yield return null;
        }
       
      
            GameStart();
        
    }
}
