using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Cure : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.partyMember;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 10;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        target.HP += 10;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);

        BattleMessage.setMessage(player.Name + " cast CURE on " + target.Name);
        BattleSystemManager.AttackInProgress = true;
        player.MP -= 10;

        yield return new WaitForSeconds(1f); //this is for the animation

        DamageDisplay.DisplayDamage(target, 10);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
