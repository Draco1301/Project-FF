using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Pheonix : MonoBehaviour, Iitems {
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
        if (target.HP == 0) {
            target.HP = target.MAX_HP/2;
        }
        
        BattleMessage.setMessage(player.Name + " used a pheonix");
        BattleSystemManager.AttackInProgress = true;
        InventoryInstance.useItem(InventoryBase.Elixer);

        yield return new WaitForSeconds(1f); //this is for the animation
        DamageDisplay.DisplayDamage(target, 15, Color.green);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
