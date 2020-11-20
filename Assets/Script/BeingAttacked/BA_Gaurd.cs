using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Gaurd : MonoBehaviour, IBeingAttacked
{
    PlayerInstance player;
    private bool actionActive = false;
    private bool wait = true;

    private void Awake() {
        player = this.GetComponent<PlayerInstance>();
    }

    private void Update() {
        if (BattleSystemManager.CheckIfPlayerIsReady(player) && !wait) {
            Destroy(this);
        }
        if (BattleSystemManager.currentPlayersTurn != this) {
            wait = true;
        }
    }

    public IEnumerator Action(CharacterInstance attacker) {
        BattleMessage.setMessage(player.Name + " blocked the attack");

        yield return null;

        Destroy(this);
    }

    public int DamageChange(float damage) {
        return 0;
    }

    public bool hasAction() {
        return true;
    }

    public bool IsActionActive() {
        return actionActive;
    }
}
