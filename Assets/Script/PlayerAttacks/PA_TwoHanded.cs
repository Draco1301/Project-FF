using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_TwoHanded : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.enemy;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 8;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage("TWO HANDED");
        player.MP -= 8;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        int damage = player.Strength * 2;
        IEnumerator damageEnumerator = ((EnemyInstance)target).takeDamage(damage, player);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
