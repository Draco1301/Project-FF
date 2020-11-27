using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Potion : MonoBehaviour, Iitems {
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
        target.HP += 15;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        BattleMessage.setMessage(player.Name + " used a potion");
        BattleSystemManager.AttackInProgress = true;
        InventoryInstance.useItem(InventoryBase.potion);

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
