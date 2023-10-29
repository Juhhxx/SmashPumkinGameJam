using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirAlçapão : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _openClip;
    [SerializeField] private AnimationClip _closeClip;
    [SerializeField] private KeyCode _openCommand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_openCommand))
        {
            _animator.Play(_openClip.name);
        }
        else if (Input.GetKeyUp(_openCommand))
        {
            _animator.Play(_closeClip.name);
        }
    }
    
}
