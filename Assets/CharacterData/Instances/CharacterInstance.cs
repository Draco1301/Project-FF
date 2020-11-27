using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstance : MonoBehaviour
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

    public float ATB = 0;

    public bool backRow;
    public Sprite sprite;
    public Vector2 pos;
}
