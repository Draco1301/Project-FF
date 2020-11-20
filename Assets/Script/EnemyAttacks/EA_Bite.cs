using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_Bite : MonoBehaviour, IEnemyAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(EnemyInstance enemy, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(enemy.Name + " Attacked " + target.Name);
        int damage = enemy.Strength;

        IBeingAttacked IBA = target.GetComponent<IBeingAttacked>();
        if (IBA != null) {
            damage = IBA.DamageChange(damage);
            if (IBA.hasAction()) {
                StartCoroutine(IBA.Action(enemy));
            }
            while (IBA.IsActionActive()) {
                yield return null;
            }
        }

        target.HP -= damage;
        target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);

        yield return new WaitForSeconds(1f);

        BattleSystemManager.AttackInProgress = false;
        BattleMessage.closeMessage();
        DestoryThis();
    }
}
