using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLoader : MonoBehaviour
{
    [SerializeField] PlayerInstance PlayerPrefab;
    [SerializeField] EnemyInstance EnemyPrefab;

    [SerializeField] PlayerBase[] pb;
    [SerializeField] EnemyBase[] eb;

    private PlayerInstance[] players;
    private EnemyInstance[] enemy;

    private void Awake() {
        players = new PlayerInstance[pb.Length];
        enemy = new EnemyInstance[eb.Length];

        for ( int i=0; i<pb.Length ;i++) {
            PlayerInstance pi = Instantiate(PlayerPrefab);
            pi.setData(pb[i]);
            players[i] = pi;
            players[i].pos = new Vector2(3.5f, 2-1.2f*i);
            players[i].transform.position = players[i].pos;
        }

        for (int i = 0; i < eb.Length; i++) {
            EnemyInstance ei = Instantiate(EnemyPrefab);
            ei.setData(eb[i]);
            enemy[i] = ei;
        }

        BattleSystemManager.setCharacters(enemy, players);
    }
}
