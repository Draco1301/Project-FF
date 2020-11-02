using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_Bite : MonoBehaviour, IEnemyAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public void StartAction(PlayerBase player, CharacterBase target) {
        Debug.Log(player.name + " Attacked " + target.name);
        target.HP -= player.Strength - target.Strength;
        
        BattleSystemManager.AttackInProgress = true;
        
        //animation
        //calc
        //display damage
        //display damage
        //animation
        
        BattleSystemManager.AttackInProgress = false;
    }
}
