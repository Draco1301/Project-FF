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

    public int Bouns_Strength;
    public int Bouns_Agility;
    public int Bouns_Stamina;
    public int Bouns_Magic;

    public Jobs main_job;
    public Jobs sub_job;

    public int GetJobLevel() {
        switch (main_job) {
            case Jobs.None:
                return 0;
            case Jobs.White:
                return WHITE_LEVEL;
            case Jobs.Black:
                return BLACK_LEVEL;
            case Jobs.Monk:
                return MONK_LEVEL;
            case Jobs.Knight:
                return KNIGHT_LEVEL;
            default:
                return 0;
        }
    }

}
