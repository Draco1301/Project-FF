using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : CharacterInstance
{
    [SerializeField] EnemyBase eb;

    public bool isEnemy = true;
    public int[] Attacks;

    public void setData(EnemyBase e) {
        LoadData(e);
    }

    private void LoadData(EnemyBase e) {
        Name = e.name;
        Strength = e.Strength;
        Agility = e.Agility;
        Stamina = e.Stamina;
        Magic = e.Magic;

        MAX_HP = e.MAX_HP;
        MAX_MP = e.MAX_MP; ;
        HP = e.HP;
        MP = e.MP;

        ATB = e.ATB;

        backRow = e.backRow;
        sprite = e.sprite;
        pos = e.pos;

        Attacks = e.Attacks;

        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.position = pos;
    }


    public IEnumerator takeDamage(int damage, PlayerInstance source) {


        IEnumerator loop = DamageDisplay.DisplayDamage(this, damage);
        while (loop.MoveNext()) {
            yield return loop.Current;
        }

        this.HP -= damage;
        this.HP = Mathf.Clamp(this.HP, 0, this.MAX_HP);
    }


}
