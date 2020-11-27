using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_Shock : MonoBehaviour, IEnemyAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(EnemyInstance enemy, PlayerInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(enemy.Name + " used Shock on " + target.Name);
        LeanAnimation.sideAnimation(enemy.gameObject, 0.2f);
        int damage = enemy.Magic;

        IEnumerator damageEnumerator = target.takeDamage(damage, enemy);
        while (damageEnumerator.MoveNext()) {
            yield return damageEnumerator.Current;
        }

        yield return new WaitForSeconds(1f);

        BattleSystemManager.AttackInProgress = false;
        BattleMessage.closeMessage();
        DestoryThis();
    }
}
