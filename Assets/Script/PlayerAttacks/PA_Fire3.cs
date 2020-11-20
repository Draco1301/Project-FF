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
        return BattleSystemManager.currentPlayersTurn.MP >= 8;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {

        target.HP -= 9999;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);

        BattleMessage.setMessage(player.Name + " cast FIRE III on " + target.Name);
        BattleSystemManager.AttackInProgress = true;
        player.MP = 0;

        yield return new WaitForSeconds(1f); //this is for the animation

        DamageDisplay.DisplayDamage(target, 9999);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
