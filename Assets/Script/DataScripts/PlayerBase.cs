using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/PlayerBase", order = 3)]
public class PlayerBase : CharacterBase
{
    public int WHITE_LEVEL;
    public int BLACK_LEVEL;
    public int KNIGHT_LEVEL;
    public int MONK_LEVEL;

    public Jobs main_job;
    public Jobs sub_job;

}
