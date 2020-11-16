using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerInstance : CharacterInstance
{
    [SerializeField] PlayerBase pb;

    public bool isEnemy = false;

    public int WHITE_LEVEL;
    public int BLACK_LEVEL;
    public int KNIGHT_LEVEL;
    public int MONK_LEVEL;

    public Jobs main_job;
    public Jobs sub_job;

    public void setData(PlayerBase p) {
        LoadData(p);
    }

    private void LoadData(PlayerBase p) {
        Name = p.name;
        Strength = p.Strength;
        Agility = p.Agility;
        Stamina = p.Stamina;
        Magic = p.Magic;

        MAX_HP = p.MAX_HP;
        MAX_MP = p.MAX_MP; ;
        HP = p.HP;
        MP = p.MP;

        ATB = p.ATB;

        backRow = p.backRow;
        sprite = p.sprite;
        pos = p.pos;

        WHITE_LEVEL = p.WHITE_LEVEL;
        BLACK_LEVEL = p.BLACK_LEVEL;
        KNIGHT_LEVEL = p.KNIGHT_LEVEL;
        MONK_LEVEL = p.MONK_LEVEL;

        main_job = p.main_job;
        sub_job = p.sub_job;

        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.position = pos;
    }

    public int GetCurrentJobLevel() {
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
        }
        return 0;
    }

}
