using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{
    
    public int Score {get; set;}

    
}
