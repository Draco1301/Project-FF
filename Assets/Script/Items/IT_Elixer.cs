using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Elixer : MonoBehaviour, Iitems {
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.partyMember;
    }

    public bool reqirementsMet() {
        return true;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        target.MP += 15;
        target.MP = Mathf.Clamp(target.MP, 0, target.MAX_MP);
        BattleMessage.setMessage(player.Name + " used an elixer");
        BattleSystemManager.AttackInProgress = true;
        InventoryInstance.useItem(InventoryBase.Elixer);

        yield return new WaitForSeconds(1f); //this is for the animation
        DamageDisplay.DisplayDamage(target, 15, Color.blue);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
