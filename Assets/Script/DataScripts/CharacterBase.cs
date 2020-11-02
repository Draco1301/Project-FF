using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Character/CharacterBase", order = 1)]
public class CharacterBase : ScriptableObject
{
    public string Name;
    public int Strength;
    public int Agility = 1;
    public int Stamina;
    public int Magic;

    public int MAX_HP;
    public int MAX_MP;
    public int HP;
    public int MP;
    
    public float ATP = 0;
    
    public bool backRow;
    public Sprite sprite;
    public Vector2 pos;
    
    public bool isEnemy;
}
