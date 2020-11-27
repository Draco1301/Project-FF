using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PA_Fight : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public bool reqirementsMet() {
        return true;
    }

    public TargetType getTargetType() {
        return TargetType.enemy;
    }
    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " attacked " + target.Name);
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);

        int damage = player.Strength / 2;
        IEnumerator damageEnumerator = ((EnemyInstance)target).takeDamage(damage, player);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }


        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }

}
