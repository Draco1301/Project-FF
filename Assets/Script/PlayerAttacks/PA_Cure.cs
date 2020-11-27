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
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " cast CURE on " + target.Name);
        player.MP -= 10;
        int heal = player.Magic;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        IEnumerator loop = ((PlayerInstance)target).heal(heal);
        while (loop.MoveNext()) {
            yield return loop.Current;
        }


        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
