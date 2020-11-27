using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_CureAll : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.partyMember;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 20;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " cast CURE on the whole party");
        player.MP -= 20;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        int heal = player.Magic / 2;
        IEnumerator damageEnumerator = ((PlayerInstance)target).heal(heal);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }


        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }

    bool MoveNext(List<IEnumerator> damageEnumerator, List<bool> bools) {
        bool b = false;
        for (int i = 0; i < damageEnumerator.Count; i++) {
            bools[i] = damageEnumerator[i].MoveNext();
            b = b || bools[i];
        }
        return b;
    }
}
