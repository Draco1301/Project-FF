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
        target.HP -= 12;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        BattleMessage.setMessage(player.Name + " cast FIRE on " + target.Name);
        BattleSystemManager.AttackInProgress = true;
        player.MP -= 5;

        yield return new WaitForSeconds(1f); //this is for the animation
        DamageDisplay.DisplayDamage(target, 12);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
