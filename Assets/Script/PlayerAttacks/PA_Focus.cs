using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Focus : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.self;
    }

    public bool reqirementsMet() {
        return true;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        
        BattleMessage.setMessage(player.Name + " increased their focus ");
        BattleSystemManager.AttackInProgress = true;
        player.focus += 1;

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
