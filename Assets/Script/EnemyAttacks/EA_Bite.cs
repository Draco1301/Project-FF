using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_Bite : MonoBehaviour, IEnemyAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(EnemyInstance player, CharacterInstance target) {
        target.HP -= player.Strength;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        
        BattleMessage.setMessage(player.Name + " Attacked " + target.Name);
        BattleSystemManager.AttackInProgress = true;

        yield return new WaitForSeconds(1f);

        BattleSystemManager.AttackInProgress = false;
        BattleMessage.closeMessage();
        DestoryThis();
    }
}
