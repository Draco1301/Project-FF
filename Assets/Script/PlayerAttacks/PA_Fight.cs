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
        target.HP -= 10;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        BattleMessage.setMessage(player.Name + " attacked " + target.Name);
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
