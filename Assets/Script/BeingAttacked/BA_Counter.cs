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
        BattleMessage.setMessage(player.Name + " counter attack");
        int damage = 5 + player.focus * 5;
        player.focus = 0;


        IEnumerator damageEnumerator = ((EnemyInstance)attacker).takeDamage(damage, player);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }


        Destroy(this);
    }

    public int DamageChange(float damage) {
        return 0;
    }

}
