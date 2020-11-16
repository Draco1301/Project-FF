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

        for (int i=0; i<players.Count;i++) {
            if (players[i].HP == 0) {
                players.RemoveAt(i);
                i--;
            }
        }
        if (players.Count == 0) {
            return;
        }

        targetPlayer = players[Random.Range(0, players.Count)];
        

        StartCoroutine(attack.StartAction(ei, targetPlayer));

    }
}
