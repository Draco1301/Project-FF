using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLoader : MonoBehaviour
{
    public static BattleLoader instance;

    [SerializeField] PlayerInstance PlayerPrefab;
    [SerializeField] EnemyInstance EnemyPrefab;

    //at the start character data transfers over
    [SerializeField] PlayerBase[] pb;
    [SerializeField] EnemyBase[] eb;

    private PlayerInstance[] players;
    [SerializeField] InventoryInstance inventory;
    private EnemyInstance[] enemy;
    private Vector2[] enemyPos;

    public static void setUpScene(PlayerBase[] p, EnemyBase[] e, Vector2[] pos, InventoryBase inventory) {
        if (instance == null) {
            BattleLoader[] bllist = GameObject.FindObjectsOfType<BattleLoader>();
            instance = bllist[0];
            for (int i=1; i<bllist.Length; i++) {
                Destroy(bllist[i].gameObject);
            }
        }

        instance.SetUpBattle(p,e,pos,inventory);
    }

    public void SetUpBattle(PlayerBase[] p, EnemyBase[] e, Vector2[] pos, InventoryBase inventory) {

        pb = p;
        eb = e;
        this.inventory.loadData(inventory);

        players = new PlayerInstance[pb.Length];
        enemy = new EnemyInstance[eb.Length];

        for ( int i=0; i<pb.Length ;i++) {
            PlayerInstance pi = Instantiate(PlayerPrefab);
            pi.loadData(pb[i]);
            players[i] = pi;
            players[i].pos = new Vector2(3.5f, 3-1.5f*i);
            players[i].transform.position = players[i].pos;
        }

        for (int i = 0; i < eb.Length; i++) {
            EnemyInstance ei = Instantiate(EnemyPrefab);
            ei.setData(eb[i]);
            ei.pos = pos[i];
            ei.transform.position = pos[i];
            ei.ATB = Random.Range(0f,1f);
            enemy[i] = ei;
        }

        BattleSystemManager.setCharacters(enemy, players);
    }

}
