using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Counter : MonoBehaviour, IPlayerAttack
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

        BattleMessage.setMessage(player.Name + " prepares their stance");
        BattleSystemManager.AttackInProgress = true;
        player.gameObject.AddComponent<BA_Counter>();
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        yield return new WaitForSeconds(1f); //this is for the animation

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
