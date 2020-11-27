using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Strike : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.enemy;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 8;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage("STRIKE");
        player.MP -= 8;
        int damage = player.Strength / 2;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        List<IEnumerator> damageEnumerator = new List<IEnumerator>();
        List<bool> contin = new List<bool>();
        foreach (EnemyInstance ei in BattleSystemManager.getEnemies()) {
            damageEnumerator.Add( ((EnemyInstance)ei).takeDamage(damage, player));
            contin.Add(false);
        }
        while (MoveNext(damageEnumerator, contin)) {
            for (int i = 0; i < damageEnumerator.Count; i++) {
                if (contin[i]) {
                    yield return damageEnumerator[i].Current;
                }
            }
        }
        damageEnumerator.Clear();
        contin.Clear();

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }

    bool MoveNext(List<IEnumerator> damageEnumerator, List<bool> bools) {
        bool b = false;
        for (int i=0; i < damageEnumerator.Count;i++) {
            bools[i] = damageEnumerator[i].MoveNext();
            b = b || bools[i];
        }
        return b;
    }
}
