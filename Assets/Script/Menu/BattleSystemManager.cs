using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour
{
    public static BattleSystemManager instance;
    public static bool AttackInProgress;

    [SerializeField] EnemyBase[] Enemies;
    [SerializeField] PlayerBase[] Players;
    private Queue<PlayerBase> playerOrder = new Queue<PlayerBase>();
    [SerializeField] ActionMenu actionMenu;
    private bool readyForAction = true;

    [SerializeField] Vector2 playerRowStart;
    [SerializeField] Vector2 enemyRowStart;
    [SerializeField] float space;
    [SerializeField] PlayerDisplay pdisplayPrefab;
    private PlayerDisplay[] pdisplays;
    [SerializeField] GameObject Pnl_Main;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else { 
            Destroy(this);
        } 
    }

    private void Start() {
        pdisplays = new PlayerDisplay[Players.Length];
        for (int i=0;i < pdisplays.Length;i++) {
            pdisplays[i] = Instantiate(pdisplayPrefab, Pnl_Main.transform);
            pdisplays[i].setUp(Players[i]);
        }
        
    }

    private void Update() {
        if (!AttackInProgress) {
            foreach (EnemyBase e in Enemies) {
                e.ATP += Time.deltaTime * e.Agility / 100.00f;
                if (e.ATP > 1) {
                    //Attack a player
                    //call enemy controller
                    //enemy controller adds attack based enemy
                }
            }
            int count = 0;
            foreach (PlayerBase p in Players) {
                p.ATP += Time.deltaTime * p.Agility / 100.00f;
                if (p.ATP > 1 && !playerOrder.Contains(p)) {
                    playerOrder.Enqueue(p);
                }
                pdisplays[count].setATB(p.ATP);
                count++;
            }
            if (playerOrder.Count > 0 && readyForAction) {
                startAttack();
            }
        }
    }

    public static EnemyBase[] getEnemies() {
        return instance.Enemies;
    }

    public static PlayerBase[] getPlayers() {
        return instance.Players;
    }

    public static void setReadyForAction(bool b) {
        instance.readyForAction = b;
    }

    private void startAttack() {
        readyForAction = false;
        actionMenu.gameObject.SetActive(true);
        actionMenu.setUp(playerOrder.Peek());
    }

    public static void endAttack() {
        BattleSystemManager.AttackInProgress = false;
        BattleSystemManager.setReadyForAction(true);
        instance.playerOrder.Dequeue();
    }
}
