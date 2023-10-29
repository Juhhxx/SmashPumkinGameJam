using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Classe especial. Imagina que é um banco de dados 
/// Podes fazer vários ScriptableObject e guardar info de cada jogador
/// Neste caso só estamos a guardar score
/// </summary>
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{
    
    public int Score {get; set;} =0;

    
}
