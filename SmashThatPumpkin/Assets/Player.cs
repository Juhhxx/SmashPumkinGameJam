using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Classe especial. Imagina que � um banco de dados 
/// Podes fazer v�rios ScriptableObject e guardar info de cada jogador
/// Neste caso s� estamos a guardar score
/// </summary>
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{
    
    public int Score {get; set;} =0;

    
}
