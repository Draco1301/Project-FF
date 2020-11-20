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

        target.HP -= player.Strength * 2;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        player.MP -= 8;

        BattleMessage.setMessage("TWO HANDED");
        BattleSystemManager.AttackInProgress = true;

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
