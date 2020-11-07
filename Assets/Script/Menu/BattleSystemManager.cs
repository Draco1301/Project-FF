using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour
{
    public static BattleSystemManager instance;
    public static bool AttackInProgress;

    List<EnemyInstance> Enemies;
    List<PlayerInstance> Players;
    private Queue<PlayerInstance> playerOrder = new Queue<PlayerInstance>();
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
        pdisplays = new PlayerDisplay[Players.Count];
        for (int i=0;i < pdisplays.Length;i++) {
            pdisplays[i] = Instantiate(pdisplayPrefab, Pnl_Main.transform);
            pdisplays[i].setUp(Players[i]);
        }
        
    }

    private void Update() {
        if (!AttackInProgress) {
            for (int i = 0; i < Enemies.Count; i++) {
                Enemies[i].ATB += Time.deltaTime * Enemies[i].Agility / 100.00f;
                if (Enemies[i].ATB > 1) {
                    Enemies[i].GetComponent<IEnemyController>().StartAttack();
                    Enemies[i].ATB = 0;
                }
            }
            for (int i = 0; i < Players.Count; i++) {
                if (Players[i].HP > 0) {
                    Players[i].ATB += Time.deltaTime * Players[i].Agility / 100.00f;
                    if (Players[i].ATB > 1 && !playerOrder.Contains(Players[i])) {
                        playerOrder.Enqueue(Players[i]);
                    }
                } else {
                    Players[i].ATB = 0;
                }
            }
            if (playerOrder.Count > 0 && readyForAction) {
                startAttack();
            }
        }
        for (int i = 0; i < Enemies.Count; i++) {
            if (Enemies[i].HP <= 0 && !AttackInProgress ) {
                Destroy(Enemies[i].gameObject);
                Enemies.RemoveAt(i);
                i--;
            }
        }
    }

    public static List<EnemyInstance> getEnemies() {
        return instance.Enemies;
    }

    public static List<PlayerInstance> getPlayers() {
        return instance.Players;
    }

    public static void setReadyForAction(bool b) {
        instance.readyForAction = b;
    }

    private void startAttack() {
        if (playerOrder.Peek().HP > 0) {
            readyForAction = false;
            actionMenu.gameObject.SetActive(true);
            actionMenu.setUp(playerOrder.Peek());
        } else {
            playerOrder.Dequeue();
        }
    }

    public static void endAttack() {
        BattleSystemManager.AttackInProgress = false;
        BattleSystemManager.setReadyForAction(true);
        instance.playerOrder.Dequeue();
    }

    public static void setCharacters(EnemyInstance[] e, PlayerInstance[] p) {
        instance.Enemies = e.ToList<EnemyInstance>();
        instance.Players = p.ToList<PlayerInstance>();
    }
}
