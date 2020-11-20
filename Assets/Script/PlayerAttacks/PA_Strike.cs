using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Strike : MonoBehaviour, IPlayerAttack
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

        foreach (EnemyInstance ei in BattleSystemManager.getEnemies()) {
            ei.HP -= 8;
            ei.HP = Mathf.Clamp(ei.HP, 0, ei.MAX_HP);
        }

        BattleMessage.setMessage("STRIKE");
        BattleSystemManager.AttackInProgress = true;
        player.MP -= 8;

        yield return new WaitForSeconds(1f); //this is for the animation

        foreach (EnemyInstance ei in BattleSystemManager.getEnemies()) {
            DamageDisplay.DisplayDamage(ei, 8);
        }

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
