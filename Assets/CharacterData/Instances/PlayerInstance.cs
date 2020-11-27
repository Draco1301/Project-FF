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
    public int secondaryAbility;

    public void loadData(PlayerBase p) {

        JobBonusStats current = JobData.getBonusStats(p);
               
        pb = p;
        Name = p.name;
        Strength = p.Strength + current.Strength;
        Agility = p.Agility + current.Agility;
        Stamina = p.Stamina + current.Stamina;
        Magic = p.Magic + current.Magic; 

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

        main_job = p.job;
        secondaryAbility = p.secondaryAbility;

        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.position = pos;
    }

    public void saveData() {

        pb.HP = HP;
        pb.MP = MP;

        pb.WHITE_LEVEL = WHITE_LEVEL;
        pb.BLACK_LEVEL = BLACK_LEVEL;
        pb.KNIGHT_LEVEL = KNIGHT_LEVEL;
        pb.MONK_LEVEL = MONK_LEVEL;

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

    public void AddExpCurrentJobLevel(int i) {
        switch (main_job) {
            case Jobs.None:
                break;
            case Jobs.White:
                WHITE_LEVEL += i;
                WHITE_LEVEL = Mathf.Clamp(WHITE_LEVEL, 0, JobData.masteredLevel);
                break;
            case Jobs.Black:
                BLACK_LEVEL += i;
                BLACK_LEVEL = Mathf.Clamp(BLACK_LEVEL, 0, JobData.masteredLevel);
                break;
            case Jobs.Monk:
                MONK_LEVEL += i;
                MONK_LEVEL = Mathf.Clamp(MONK_LEVEL, 0, JobData.masteredLevel);
                break;
            case Jobs.Knight:
                KNIGHT_LEVEL += i;
                KNIGHT_LEVEL = Mathf.Clamp(KNIGHT_LEVEL, 0, JobData.masteredLevel);
                break;
        }
    }

    public int focus = 0;

    public IEnumerator takeDamage(int damage, EnemyInstance source) {
        
        IBeingAttacked IBA = this.GetComponent<IBeingAttacked>();
        if (IBA != null) {
            damage = IBA.DamageChange(damage);
            IEnumerator IBALoop = IBA.Action(source);
            while (IBALoop.MoveNext()) {
                yield return IBALoop.Current;
            }
        }

        damage = Mathf.Clamp(damage, 0, 9999);
        this.HP -= damage;
        this.HP = Mathf.Clamp(this.HP, 0, this.MAX_HP);

        IEnumerator loop = DamageDisplay.DisplayDamage(this, damage);
        while (loop.MoveNext()) {
            yield return loop.Current;
        }
    }

    public IEnumerator heal(int heal) {
        heal = Mathf.Clamp(heal, 0, 9999);
        this.HP += heal;
        this.HP = Mathf.Clamp(this.HP, 0, this.MAX_HP);

        IEnumerator loop = DamageDisplay.DisplayDamage(this, heal);
        while (loop.MoveNext()) {
            yield return loop.Current;
        }
    }
}
