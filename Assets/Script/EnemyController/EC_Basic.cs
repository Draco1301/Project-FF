using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Basic : MonoBehaviour, IEnemyController
{
    EnemyInstance ei;
    List<PlayerInstance> players;
    PlayerInstance targetPlayer;
    IEnemyAttack attack;

    private void Awake() {
        ei = GetComponent<EnemyInstance>();
    }

    public void StartAttack() {

        int attackChoosen = ei.Attacks[Random.Range(0, ei.Attacks.Length)];

        EnemyAttackIndex.getAttack(this.gameObject, attackChoosen);
        attack = GetComponent<IEnemyAttack>();

        players = BattleSystemManager.getPlayers();
        while (targetPlayer == null || targetPlayer.HP == 0) {
            targetPlayer = players[Random.Range(0, ei.Attacks.Length)];
        }

        StartCoroutine(attack.StartAction(ei, targetPlayer));

    }
}
