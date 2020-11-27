using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_Gust : MonoBehaviour, IEnemyAttack {

    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(EnemyInstance enemy, PlayerInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(enemy.Name + " used Gust ");
        LeanAnimation.sideAnimation(enemy.gameObject, 0.2f);
        int damage = enemy.Magic*2/3;
               
        List<IEnumerator> damageEnumerator = new List<IEnumerator>();
        List<bool> contin = new List<bool>();
        foreach (PlayerInstance pi in BattleSystemManager.getPlayers()) {
            damageEnumerator.Add(((PlayerInstance)pi).takeDamage(damage, enemy));
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

        yield return new WaitForSeconds(1f);

        BattleSystemManager.AttackInProgress = false;
        BattleMessage.closeMessage();
        DestoryThis();
    }

    bool MoveNext(List<IEnumerator> damageEnumerator, List<bool> bools) {
        bool b = false;
        for (int i = 0; i < damageEnumerator.Count; i++) {
            bools[i] = damageEnumerator[i].MoveNext();
            b = b || bools[i];
        }
        return b;
    }
}
