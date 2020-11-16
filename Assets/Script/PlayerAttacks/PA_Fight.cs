using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PA_Fight : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        target.HP -= player.Strength;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        BattleMessage.setMessage(player.Name + " Attacked " + target.Name);
        BattleSystemManager.AttackInProgress = true;

        yield return new WaitForSeconds(1f); //this is for the animation
        DamageDisplay.DisplayDamage(target, player.Strength);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
