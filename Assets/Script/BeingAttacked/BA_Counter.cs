using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Counter : MonoBehaviour, IBeingAttacked
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
        actionActive = true;
        BattleMessage.setMessage(player.Name + " counter attack");
        int damage = 5 + player.focus * 5;
        player.focus = 0;

        attacker.HP -= damage;
        attacker.HP = Mathf.Clamp(attacker.HP, 0, attacker.MAX_HP);

        yield return new WaitForSeconds(1f); // animation;

        DamageDisplay.DisplayDamage(attacker, damage);

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        Debug.Log("here");
        Destroy(this);
        actionActive = false;
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
