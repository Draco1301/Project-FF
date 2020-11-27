using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Fire : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.enemy;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 5;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " cast FIRE on " + target.Name);
        player.MP -= 5;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);

        int damage = player.Magic;
        IEnumerator damageEnumerator = ((EnemyInstance)target).takeDamage(damage, player);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
