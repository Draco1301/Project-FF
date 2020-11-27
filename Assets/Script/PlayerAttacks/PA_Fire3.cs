using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Fire3 : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.enemy;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= BattleSystemManager.currentPlayersTurn.MAX_MP/4;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " cast FIRE III on " + target.Name);
        player.MP -= player.MAX_MP/4;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        int damage = player.Magic * 3;
        IEnumerator damageEnumerator = ((EnemyInstance)target).takeDamage(damage, player);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }


        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
